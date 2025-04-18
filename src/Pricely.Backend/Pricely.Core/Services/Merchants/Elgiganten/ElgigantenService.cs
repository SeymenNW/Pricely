using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pricely.Core.Extensions;
using Pricely.Libraries.Shared.Enums;
using Pricely.Libraries.Shared.Models;
using Pricely.Libraries.Shared.ResponseModels.Elgiganten;

namespace Pricely.Core.Services.Merchants.Elgiganten
{
    public class ElgigantenService : Merchant, IElgigantenService
    {
        private readonly HttpClient _httpClient;
        public ElgigantenService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
            _httpClient.DefaultRequestHeaders.Add("Accept-Language", "da,en-US;q=0.7,en;q=0.3");
            _httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br, zstd");
            _httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            _httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
            _httpClient.DefaultRequestHeaders.Add("Host", "www.elgiganten.dk");
        }

        public override async Task<UnifiedProductDetails?> GetProductDetailsAsync(string sku)
        {

            string productUrl = $"https://www.elgiganten.dk/api/product/{sku}";
            HttpResponseMessage response = await _httpClient.GetAsync(productUrl);

            if (!response.IsSuccessStatusCode)
            {

                throw new Exception("Could not load product details");
            }


            string jsonResponse = await response.DecompressAsStringAsync();
            ElgigantenProductResponse productDetails = JsonConvert.DeserializeObject<ElgigantenProductResponse>(jsonResponse);

            var image = new List<string>();
            image.Add(productDetails.ImageUrl);
            return new UnifiedProductDetails
            {
                Name = productDetails.Name,
                Brand = productDetails.Brand,
                Description = "No Description Available",
                Gtin = "No Gtin Available",
                Merchant = MerchantEnum.Elgiganten,
                Price = productDetails.Price.Current[0].ToString(),
                Images = image


            };
        }

        public override async IAsyncEnumerable<UnifiedProductPreview> GetProductsFromSearchAsync(string query)
        {
            ElgigantenSearchResponse payload = new(query);
            string jsonPayload = JsonConvert.SerializeObject(payload);

            HttpResponseMessage response = await _httpClient.PostAsync("https://www.elgiganten.dk/api/search", new StringContent(jsonPayload, Encoding.UTF8, "application/json"));
            string jsonResponse = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                yield break;
                throw new Exception("Failed to load Price Data from Elgiganten.");
            }

            string responseJson = await response.DecompressAsStringAsync();
            ElgigantenResponse elgigantenResponse = JsonConvert.DeserializeObject<ElgigantenResponse>(responseJson);

            if (elgigantenResponse == null || !elgigantenResponse.Data.Records.Any())
            {
                yield break;
            }

            //Note: Needs to be separated to adhere to SOLID.
            foreach (var product in elgigantenResponse.Data.Records)
            {
                yield return new UnifiedProductPreview
                {
                    Name = product.Name,
                    CurrentPrice = product.Price?.Current?[0],
                    IdSku = product.Sku,
                    Url = $"https://www.elgiganten.dk{product.Href}",
                    Image = product.ImageUrl,
                    Merchant = MerchantEnum.Elgiganten,
                };

            }


        }
    }
}
