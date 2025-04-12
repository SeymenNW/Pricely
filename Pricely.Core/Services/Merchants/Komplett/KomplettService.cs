using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pricely.Core.Extensions;
using Pricely.Libraries.Shared.Models;
using Pricely.Libraries.Shared.ResponseModels.Komplett;

namespace Pricely.Core.Services.Merchants.Komplett
{
    public class KomplettService : Merchant, IKomplettService
    {

        private readonly HttpClient _httpClient;
        public KomplettService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
            _httpClient.DefaultRequestHeaders.Add("Accept-Language", "da,en-US;q=0.7,en;q=0.3");
            _httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br, zstd");
            _httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            _httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
            _httpClient.DefaultRequestHeaders.Add("Host", "www.komplett.dk");
        }


        public override async Task<UnifiedProductDetails?> GetProductDetailsAsync(string sku)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://www.komplett.dk/api/v1/searchpage?q={sku}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to load Price Data from Komplett.");
            }

            string responseJson = await response.DecompressAsStringAsync();
            KomplettProductSearch komplettResponse = JsonConvert.DeserializeObject<KomplettProductSearch>(responseJson);

            var product = komplettResponse.Products[0];

            return new UnifiedProductDetails
            {
                Name = product.Name,
                Price = product.Price.ListPrice,
                Description = product.Description,
                ImageUrls = product.Images,
                Gtin = "0",
                Merchant = "Komplett",
                Brand = "Not Specified"
            };
        }

        public override async IAsyncEnumerable<UnifiedProductPreview> GetProductsFromSearchAsync(string query)
        {

            HttpResponseMessage response = await _httpClient.GetAsync($"https://www.komplett.dk/api/v1/searchpage?q={query.Replace(" ", "+")}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to load Price Data from Komplett.");
            }

            string responseJson = await response.DecompressAsStringAsync();
            KomplettProductSearch komplettResponse = JsonConvert.DeserializeObject<KomplettProductSearch>(responseJson);

            //Note: Needs to be separated to adhere to SOLID.
            foreach (var product in komplettResponse.Products)
            {
                yield return new UnifiedProductPreview
                {
                    Name = product.Name,
                    CurrentPrice = product.Price.ListPrice,
                    IdSku = product.MaterialNumber,
                    Url = $"https://www.komplett.dk{product.Url}",
                    ImageUrl = product.Images[0],
                    Merchant = "Komplett"
                };

            }


        }

    }
}
