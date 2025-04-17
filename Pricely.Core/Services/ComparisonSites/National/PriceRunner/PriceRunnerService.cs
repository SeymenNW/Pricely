using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pricely.Core.Extensions;
using Pricely.Core.Extensions.HttpClientExtensions;
using Pricely.Libraries.Shared.Models;
using Pricely.Libraries.Shared.ResponseModels.ComparisonSites.PriceRunner;


//This is LEGACY (ported) code that will be rewritten to match SOLID and Best Practices.
namespace Pricely.Core.Services.ComparisonSites.National.PriceRunner
{
    public class PriceRunnerService : IPriceRunnerService
    {

        private readonly HttpClient _httpClient;

        public PriceRunnerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        #region Product Searching Function
        //Eksempel Søgning: https://www.pricerunner.dk/dk/api/search-compare-gateway/public/search/v5/DK?q=IPHONE&suggestionsActive=true&suggestionClicked=false&suggestionReverted=false&carouselSize=10
        public async Task<PriceRunnerSearchResults> GetProductsFromSearch(string search)
        {
            string searchToUrl = search.Replace(" ", "%20");

            string prSearchUrl = $"https://www.pricerunner.dk/dk/api/search-compare-gateway/public/search/v5/DK?q={searchToUrl}&size=48&offset=68&suggestionsActive=true&suggestionClicked=false&suggestionReverted=false";

            var jsonSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };


            try
            {
                //Tilføjer NØDVENDIGE headers med en extension metode (i mappen Extensions)
                _httpClient.AddCommonHeaders();

                HttpRequestMessage httpRequestMsg = new(HttpMethod.Get, prSearchUrl);
                HttpResponseMessage httpResponseMsg = await _httpClient.SendAsync(httpRequestMsg);
                httpResponseMsg.EnsureSuccessStatusCode();

                //Tjekker om responsen er Json, Gzip eller Deflate og decompresser hvis det er GZip eller deflate. Extension metode til HttpResponseMessage
                string jsonString = await httpResponseMsg.DecompressAsStringAsync();
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

                    Regex rgx = new Regex(@"\d+");
                    Match rgxMatch = rgx.Match(prProduct.Category.Id);

                    if (rgxMatch.Success)
                    {
                        pricelyProduct.ProductCategoryNum = rgxMatch.Value;
                    }




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

        #endregion

        #region Product Details Function
        public async Task<PriceRunnerProductDetails> GetProductDetailsFromId(string productId, string productCategoryNum)
        {


            string prDetailsUrl = $"https://www.pricerunner.dk/dk/api/search-compare-gateway/public/product-detail/v0/offers/DK/{productId}";
            string prListingUrl = $"https://www.pricerunner.dk/dk/api/search-compare-gateway/public/productlistings/pl/initial/{productCategoryNum}-{productId}/DK";

            var jsonSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };




            try
                {


                    //Tilføjer NØDVENDIGE headers med en extension metode (i mappen Extensions)
                    _httpClient.AddCommonHeaders();
                    _httpClient.DefaultRequestHeaders.Add("authority", "www.pricerunner.dk");

                    HttpResponseMessage httpResponseDetails = await _httpClient.GetAsync(prDetailsUrl);
                    await Task.Delay(100);

                    HttpResponseMessage httpResponseListing = await _httpClient.GetAsync(prListingUrl);

                    httpResponseDetails.EnsureSuccessStatusCode();
                    httpResponseListing.EnsureSuccessStatusCode();

                    //Tjekker om responsen er Json, Gzip eller Deflate og decompresser hvis det er GZip eller deflate. Extension metode til HttpResponseMessage
                    string detailsJsonResponse = await httpResponseDetails.DecompressAsStringAsync();
                    string listingJsonResponse = await httpResponseListing.DecompressAsStringAsync();

                    PRProductDetail prProductDetail = JsonConvert.DeserializeObject<PRProductDetail>(detailsJsonResponse, jsonSettings);
                    PRProductListing prProductListing = JsonConvert.DeserializeObject<PRProductListing>(listingJsonResponse, jsonSettings);




                    List<PriceRunnerMerchants> merchantsList = new();

                    foreach (var offer in prProductDetail.Offers)
                    {
                        string productUrl = $"https://www.pricerunner.dk{offer.Url}";

                        HttpResponseMessage productUrlResponse = await _httpClient.GetAsync(productUrl);
                        productUrl = productUrlResponse.RequestMessage.RequestUri.ToString();


                        //https://www.pricerunner.dk/dk/api/search-compare-gateway/gotostore/v1/DK/be2c34f405440ab76ef658e6987c635f?productId=3211644574

                        PDMerchant merchantFromId = prProductDetail?.Merchants[offer.MerchantId];
                        PriceRunnerMerchants merchants = new PriceRunnerMerchants
                        {
                            Id = offer?.MerchantId,
                            Name = merchantFromId?.Name,
                            MerchantProductName = offer?.Name,
                            ProductUrl = productUrl,
                            Price = offer?.Price?.Amount,
                            StockStatus = offer?.StockStatus == "IN_STOCK" ? true : false,
                            Availability = offer?.Availability == "AVAILABLE" ? true : false,
                            ShippingCost = offer?.ShippingCost?.Amount,
                            MerchantRating = merchantFromId?.Rating?.Average == "0.0" ? null : merchantFromId?.Rating?.Average,
                            MerchantLogoUrl = merchantFromId?.Logo?.Url



                        };

                        merchantsList.Add(merchants);
                    }



                    return new PriceRunnerProductDetails
                    {
                        Name = prProductListing?.ProductDetails?.Name,
                        Brand = prProductListing?.Brand?.Name,
                        ImageUrls = prProductDetail?.Images?.Select(imageUrl => $"https://owp.klarna.com{imageUrl?.Path}").ToList(),
                        Merchants = merchantsList,
                        Description = prProductListing?.ProductDetails?.Description,
                        MinPrice = prProductListing?.PrioritizedMinPrice?.Amount,
                        MaxPrice = prProductListing?.PrioritizedMaxPrice?.Amount,
                        PriceRunnerUrl = "https://www.pricerunner.dk" + prProductListing?.ProductDetails?.Url




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


