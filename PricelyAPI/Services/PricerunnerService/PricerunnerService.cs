using Newtonsoft.Json;
using Pricely.Libraries.Services.Models.PriceRunner;
using PricelyAPI.Helpers.Extensions;
using PricelyAPI.Helpers.Handlers;
using PricelyAPI.ServiceModels.Pricerunner;
using System.IO.Compression;
using System.Net;
using static System.Net.WebRequestMethods;

namespace PricelyAPI.Services.PricerunnerService
{
    public class PriceRunnerService : IPriceRunnerService
    {
        #region Produktsøgning funktion
        //Eksempel Søgning: https://www.pricerunner.dk/dk/api/search-compare-gateway/public/search/v5/DK?q=IPHONE&suggestionsActive=true&suggestionClicked=false&suggestionReverted=false&carouselSize=10
        public async Task<PriceRunnerSearchResults> GetProductsFromSearch(string search)
        {
            string searchToUrl = search.Replace(" ", "%20");

            string prSearchUrl = $"https://www.pricerunner.dk/dk/api/search-compare-gateway/public/search/v5/DK?q={searchToUrl}&suggestionsActive=true&suggestionClicked=false&suggestionReverted=false&carouselSize=10";

            var jsonSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };

            using (HttpClient httpClient = new(ProxyManager.AddRotatingProxy()))
            {
                try
                {
                    //Tilføjer NØDVENDIGE headers med en extension metode (i mappen Extensions)
                    httpClient.AddHeaders();

                    HttpRequestMessage httpRequestMsg = new(HttpMethod.Get, prSearchUrl);
                    HttpResponseMessage httpResponseMsg = await httpClient.SendAsync(httpRequestMsg);
                    httpResponseMsg.EnsureSuccessStatusCode();

                    //Tjekker om responsen er Json, Gzip eller Deflate og decompresser hvis det er GZip eller deflate. Extension metode til HttpResponseMessage
                    string jsonString = await httpResponseMsg.GetJsonAsString();
                    PRProductSearch prSearch = JsonConvert.DeserializeObject<PRProductSearch>(jsonString, jsonSettings);

                    PriceRunnerSearchResults prToPricelyResults = new();
                    prToPricelyResults.SearchQuery = prSearch.SearchQuery;

                    foreach (var prProduct in prSearch.Products)
                    {
                        PriceRunnerSearchResultProduct pricelyProduct = new();
                        pricelyProduct.Name = prProduct.Name;
                        pricelyProduct.Description = prProduct.Description;
                        pricelyProduct.Id = prProduct.Id;
                        pricelyProduct.ImageUrl = $"https://owp.klarna.com{prProduct.Image.Path}";
                        pricelyProduct.LowestPrice = prProduct.LowestPrice.Amount;

                        prToPricelyResults.ProductResults.Add(pricelyProduct);

                    }

                    return prToPricelyResults;

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Fejl, kan ikke hente data. {e.Message}");
                    return null;
                }
            }
        }
        #endregion

        #region Produkt detaljer funktion
        public async Task<PriceRunnerProductDetails> GetProductDetailsFromId(string productId)
        {


            string prDetailsUrl = $"https://www.pricerunner.dk/dk/api/search-compare-gateway/public/product-detail/v0/offers/DK/{productId}";
            string prListingUrl = $"https://www.pricerunner.dk/dk/api/search-compare-gateway/public/productlistings/pl/initial/52-{productId}/DK";

            var jsonSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };




            using (HttpClient httpClient = new(ProxyManager.AddRotatingProxy()))
            {
                try
                {
               

                    //Tilføjer NØDVENDIGE headers med en extension metode (i mappen Extensions)
                    httpClient.AddHeaders();
                    httpClient.DefaultRequestHeaders.Add("authority", "www.pricerunner.dk");
                    httpClient.DefaultRequestHeaders.Add("Authorization", "36DD6CFC5B15E43DC18C66455116F244");

                    HttpResponseMessage httpResponseDetails = await httpClient.GetAsync(prDetailsUrl);
                    HttpResponseMessage httpResponseListing = await httpClient.GetAsync(prListingUrl);

                    httpResponseDetails.EnsureSuccessStatusCode();
                    httpResponseListing.EnsureSuccessStatusCode();

                    //Tjekker om responsen er Json, Gzip eller Deflate og decompresser hvis det er GZip eller deflate. Extension metode til HttpResponseMessage
                    string detailsJsonResponse = await httpResponseDetails.GetJsonAsString();
                    string listingJsonResponse = await httpResponseListing.GetJsonAsString();

                    PRProductDetail prProductDetail = JsonConvert.DeserializeObject<PRProductDetail>(detailsJsonResponse, jsonSettings);
                    PRProductListing prProductListing = JsonConvert.DeserializeObject<PRProductListing>(listingJsonResponse, jsonSettings);




                    List<PriceRunnerMerchants> merchantsList = new();

                    foreach (var offer in prProductDetail.Offers)
                    {
                        string productUrl = "https://www.pricerunner.dk/dk/api/search-compare-gateway" + offer.Url;

                        HttpResponseMessage productUrlResponse = await httpClient.GetAsync(productUrl);
                        productUrl = productUrlResponse.RequestMessage.RequestUri.ToString();


                        //https://www.pricerunner.dk/dk/api/search-compare-gateway/gotostore/v1/DK/be2c34f405440ab76ef658e6987c635f?productId=3211644574


                        PriceRunnerMerchants merchants = new PriceRunnerMerchants
                        {
                            Id = offer.Id,
                            Name = prProductDetail.Merchants[offer.MerchantId].Name,
                            MerchantProductName = offer.Name,
                            ProductUrl = productUrl,

                        };

                        merchantsList.Add(merchants);
                    }



                    return new PriceRunnerProductDetails
                    {
                        Name = prProductListing.ProductDetails.Name,
                        Brand = prProductListing.Brand.Name,
                        ImageUrls = prProductDetail.Images.Select(imageUrl => $"https://owp.klarna.com{imageUrl.Path}").ToList(),
                        Merchants = merchantsList,
                        Description = prProductListing.ProductDetails.Description,
                        MinPrice = prProductListing.PrioritizedMinPrice.Amount,
                        MaxPrice = prProductListing.PrioritizedMaxPrice.Amount,
                        PriceRunnerUrl = "https://www.pricerunner.dk"+prProductListing.ProductDetails.Url




                    };





                }
                catch (Exception e)
                {
                    Console.WriteLine($"Fejl, kan ikke hente data. {e.Message}");
                    return null;
                }

            }
        }
        #endregion
    }
}
