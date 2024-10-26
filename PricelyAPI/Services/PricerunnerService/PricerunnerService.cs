using Newtonsoft.Json;
using PricelyAPI.Helpers.Extensions;
using PricelyAPI.ServiceModels.Pricerunner;
using System.IO.Compression;

namespace PricelyAPI.Services.PricerunnerService
{
    public class PricerunnerService : IPricerunnerService
    {

        //Eksempel Søgning: https://www.pricerunner.dk/dk/api/search-compare-gateway/public/search/v5/DK?q=IPHONE&suggestionsActive=true&suggestionClicked=false&suggestionReverted=false&carouselSize=10
        public async Task<PricerunnerProductSearch> GetProductsFromSearch(string search)
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
                    string jsonString = await httpResponseMsg.GetJsonString();

                  
                        PricerunnerProductSearch prSearch = JsonConvert.DeserializeObject<PricerunnerProductSearch>(jsonString, jsonSettings);
                        return prSearch;

                    

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Fejl, kan ikke hente data. {e.Message}");
                    return null;
                }
            }
        }

        private async Task GetProductDetails(string productUrl)
        {

        }



    }
}
