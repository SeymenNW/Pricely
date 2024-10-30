﻿using Newtonsoft.Json;
using Pricely.Libraries.Services.Models.PriceRunner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

//DENNE BRUGES IKKE LÆNGERE (HttpRequestne bliver foretaget direkte i Razor components nu).
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
        public async Task<PriceRunnerProductDetails> GetProductDetailsFromId(string productId)
        {
            

            string pricelySearchUrl = $"https://localhost:7036/v1/pr/details/{productId}";

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
