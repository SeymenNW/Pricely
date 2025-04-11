using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pricely.Libraries.Shared.Models;
using Pricely.Libraries.Shared.ResponseModels.Elgiganten;

namespace Pricely.Core.Services.Merchants.Elgiganten
{
    public class ElgigantenService : IElgigantenService
    {
        private readonly HttpClient _httpClient;
        public ElgigantenService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async IAsyncEnumerable<UnifiedProductPreview> GetProductsFromSearchAsync(string query)
        {
            ElgigantenProductSearch payload = new(query);
            string jsonPayload = JsonConvert.SerializeObject(payload);

            HttpResponseMessage response = await _httpClient.PostAsync("https://www.elgiganten.dk/api/search", new StringContent(jsonPayload, Encoding.UTF8, "application/json"));
            string jsonResponse = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to load Price Data from Elgiganten.");
            }

            string responseJson = await response.Content.ReadAsStringAsync();
                ElgigantenResponse elgigantenResponse = JsonConvert.DeserializeObject<ElgigantenResponse>(responseJson);

                //Note: Needs to be separated to adhere to SOLID.
                 foreach (var product in elgigantenResponse.Data.Records)
                {
                   yield return new UnifiedProductPreview
                    {
                        Name = product.Name,
                        CurrentPrice = product.Price?.Current?[0],
                        IdSku = product.Sku,
                        Url = $"https://www.elgiganten.dk{product.Href}",
                        ImageUrl = product.ImageUrl,
                        Merchant = "Elgiganten"
                    };

                }
           
           
        }
    }
}
