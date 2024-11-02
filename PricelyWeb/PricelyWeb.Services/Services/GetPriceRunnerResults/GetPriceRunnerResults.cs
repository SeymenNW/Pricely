using Newtonsoft.Json;
using Pricely.Libraries.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PricelyWeb.Services
{
    public class GetPriceRunnerResults : IGetPriceRunnerResults
    {
        private readonly string _apiUrl;

        public GetPriceRunnerResults(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        #region Produktsøgning funktion
        public async Task<PriceRunnerSearchResults> GetProductsFromSearch(string search)
        {
            string searchToUrl = search.Replace(" ", "%20");

            string pricelySearchUrl = $"{_apiUrl}/v1/pr/search/{searchToUrl}";

            var jsonSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };

            using (HttpClient httpClient = new())
            {
                try
                {
                    //Tilføjer NØDVENDIGE headers med en extension metode (i mappen Extensions)

                    HttpRequestMessage httpRequestMsg = new(HttpMethod.Get, pricelySearchUrl);
                    HttpResponseMessage httpResponseMsg = await httpClient.SendAsync(httpRequestMsg);
                    httpResponseMsg.EnsureSuccessStatusCode();
                    string jsonString = await httpResponseMsg.Content.ReadAsStringAsync();


                    PriceRunnerSearchResults results = JsonConvert.DeserializeObject<PriceRunnerSearchResults>(jsonString);

                    return results;

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Fejl, kan ikke hente data. {e.Message}");
                    return null;
                }
            }
        }
        #endregion


        #region Produktsøgning funktion
        public async Task<PriceRunnerProductDetails> GetProductDetailsFromId(string productId, string categoryId)
        {


            string pricelySearchUrl = $"{_apiUrl}/v1/pr/details/{categoryId}/{productId}";

            var jsonSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };

            using (HttpClient httpClient = new())
            {
                try
                {

                    HttpRequestMessage httpRequestMsg = new(HttpMethod.Get, pricelySearchUrl);
                    HttpResponseMessage httpResponseMsg = await httpClient.SendAsync(httpRequestMsg);
                    httpResponseMsg.EnsureSuccessStatusCode();
                    string jsonString = await httpResponseMsg.Content.ReadAsStringAsync();


                    PriceRunnerProductDetails results = JsonConvert.DeserializeObject<PriceRunnerProductDetails>(jsonString);

                    return results;

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
