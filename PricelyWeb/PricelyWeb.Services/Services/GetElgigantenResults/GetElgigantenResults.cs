using Newtonsoft.Json;
using Pricely.Libraries.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricelyWeb.Services
{
    public class GetElgigantenResults : IGetElgigantenResults
    {
        private readonly string _apiUrl;

        public GetElgigantenResults(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        #region Produktsøgning funktion
        public async Task<ElgigantenSearchResults> GetProductsFromSearch(string search)
        {
            string searchToUrl = search.Replace(" ", "%20");

            string elgigantenSearchUrl = $"{_apiUrl}/v1/eg/search/{searchToUrl}";

            var jsonSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };

            using (HttpClient httpClient = new())
            {
                try
                {
                    //Tilføjer NØDVENDIGE headers med en extension metode (i mappen Extensions)

                    HttpRequestMessage httpRequestMsg = new(HttpMethod.Get, elgigantenSearchUrl);
                    HttpResponseMessage httpResponseMsg = await httpClient.SendAsync(httpRequestMsg);
                    httpResponseMsg.EnsureSuccessStatusCode();
                    string jsonString = await httpResponseMsg.Content.ReadAsStringAsync();


                    ElgigantenSearchResults results = JsonConvert.DeserializeObject<ElgigantenSearchResults>(jsonString);

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
