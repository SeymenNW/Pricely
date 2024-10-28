using Newtonsoft.Json;
using Pricely.Libraries.Services.Models.PriceRunner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pricely.Libraries.Services.Services
{
    public class GetPriceRunnerResults : IGetPriceRunnerResults
    {

        #region Produktsøgning funktion
        public async Task<PriceRunnerSearchResults> GetProductsFromSearch(string search)
        {
            string searchToUrl = search.Replace(" ", "%20");

            string pricelySearchUrl = $"https://localhost:7036/v1/pr/search/{searchToUrl}";

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
    }
}
