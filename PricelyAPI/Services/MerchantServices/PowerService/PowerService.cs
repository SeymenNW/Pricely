using Newtonsoft.Json;
using Pricely.Libraries.Shared.Models;
using PricelyAPI.Helpers.Extensions;
using PricelyAPI.Helpers.Handlers;
using PricelyAPI.Services.MerchantServices.PriceRunnerService.PriceRunner;
using System.Text.RegularExpressions;

namespace PricelyAPI.Services.MerchantServices.PowerService
{
    public class PowerService
    {
        #region Produktsøgning funktion
        //Eksempel Søgning: https://www.pricerunner.dk/dk/api/search-compare-gateway/public/search/v5/DK?q=IPHONE&suggestionsActive=true&suggestionClicked=false&suggestionReverted=false&carouselSize=10
        public async Task<PriceRunnerSearchResults> GetProductsFromSearch(string search)
        {
            string searchToUrl = search.Replace(" ", "%20");

            string prSearchUrl = $"https://www.pricerunner.dk/dk/api/search-compare-gateway/public/search/v5/DK?q={searchToUrl}&size=48&offset=68&suggestionsActive=true&suggestionClicked=false&suggestionReverted=false";

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
        }
        #endregion
    }
}
