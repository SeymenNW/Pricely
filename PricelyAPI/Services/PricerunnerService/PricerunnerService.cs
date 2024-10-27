using Newtonsoft.Json;
using Pricely.Libraries.Services.Models.PriceRunner;
using PricelyAPI.Helpers.Extensions;
using PricelyAPI.ServiceModels.Pricerunner;
using System.IO.Compression;

namespace PricelyAPI.Services.PricerunnerService
{
    public class PriceRunnerService : IPriceRunnerService
    {

        //Eksempel Søgning: https://www.pricerunner.dk/dk/api/search-compare-gateway/public/search/v5/DK?q=IPHONE&suggestionsActive=true&suggestionClicked=false&suggestionReverted=false&carouselSize=10
        public async Task<PriceRunnerSearchResults> GetProductsFromSearch(string search)
        {
            string searchToUrl = search.Replace(" ", "%20");

            string prSearchUrl = $"https://www.pricerunner.dk/dk/api/search-compare-gateway/public/search/v5/DK?q={searchToUrl}&suggestionsActive=true&suggestionClicked=false&suggestionReverted=false&carouselSize=10";

            var jsonSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };

            using (HttpClient httpClient = new())
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

        public async Task<PriceRunnerProductDetails> GetProductDetailsFromId(string productId)
        {


            string prDetailsUrl = $"https://www.pricerunner.dk/dk/api/search-compare-gateway/public/product-detail/v0/offers/DK/{productId}";

            var jsonSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };

            using (HttpClient httpClient = new())
            {
                try
                {
                    //Tilføjer NØDVENDIGE headers med en extension metode (i mappen Extensions)
                    httpClient.AddHeaders();

                    HttpRequestMessage httpRequestMsg = new(HttpMethod.Get, prDetailsUrl);
                    HttpResponseMessage httpResponseMsg = await httpClient.SendAsync(httpRequestMsg);
                    httpResponseMsg.EnsureSuccessStatusCode();

                    //Tjekker om responsen er Json, Gzip eller Deflate og decompresser hvis det er GZip eller deflate. Extension metode til HttpResponseMessage
                    string jsonString = await httpResponseMsg.GetJsonAsString();
                    PRProductDetail prProductDetail = JsonConvert.DeserializeObject<PRProductDetail>(jsonString, jsonSettings);

                    return new PriceRunnerProductDetails
                    {
                        Name = prProductDetail.Images[0].Description, //Dette er en midlertidig løsning
                        Brand = "Ikke specifieret endnu",
                        ImageUrls = prProductDetail.Images.Select(imageUrl => "https://owp.klarna.com"+imageUrl.Path).ToList(),
                        
                    };

                    httpResponseMsg.EnsureSuccessStatusCode();




                }
                catch (Exception e)
                {
                    Console.WriteLine($"Fejl, kan ikke hente data. {e.Message}");
                    return null;
                }

            }
        }

    }
}
