using Newtonsoft.Json;
using Pricely.Libraries.Services.Models.Elgiganten;
using Pricely.Libraries.Services.Models.PriceRunner;
using PricelyAPI.Helpers.Extensions;
using PricelyAPI.ServiceModels.Elgiganten;
using PricelyAPI.ServiceModels.Pricerunner;
using System;
using System.Text;

namespace PricelyAPI.Services.ElgigantenService
{
    public class ElgigantenService : IElgigantenService
    {
        #region Produktsøgning funktion
        public async Task<ElgigantenSearchResults> GetProductsFromSearch(string search)
        {
            string egApiUrl = $"https://www.elgiganten.dk/api/search";

            var jsonSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };

            using (HttpClient httpClient = new())
            {
                try
                {

                    EGProductSearch payload = new(search);
                    string jsonPayload = JsonConvert.SerializeObject(payload).ToString();

                    HttpResponseMessage httpResponseMsg = await httpClient.PostAsync(egApiUrl, new StringContent(jsonPayload, Encoding.UTF8, "application/json"));
                    string jsonString = await httpResponseMsg.GetJsonAsString();


                    dynamic egSearch = JsonConvert.DeserializeObject<dynamic>(jsonString, jsonSettings);


                    ElgigantenSearchResults egToPricelyResults = new();
                    egToPricelyResults.SearchQuery = search;

                    foreach (var egProduct in egSearch.data.records)
                    {
                        ElgigantenSearchResultProduct pricelyProduct = new();
                        pricelyProduct.Name = (string)egProduct?.name;
                        //pricelyProduct.Description = egProduct?.Description;
                        //pricelyProduct.Id = egProduct.Id;
                        //pricelyProduct.ImageUrl Fungerer ikke lige nu.
                        pricelyProduct.CurrentPrice = (string)egProduct?.price?.current[0];

                        egToPricelyResults.ProductResults.Add(pricelyProduct);

                    }

                    return egToPricelyResults;

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
