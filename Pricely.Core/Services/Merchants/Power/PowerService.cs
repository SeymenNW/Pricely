using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pricely.Core.Extensions;
using Pricely.Libraries.Shared.Models;
using Pricely.Libraries.Shared.ResponseModels.Elgiganten;
using Pricely.Libraries.Shared.ResponseModels.Power;

namespace Pricely.Core.Services.Merchants.Power
{
    public class PowerService : Merchant, IPowerService
    {

        private readonly HttpClient _httpClient;
        public PowerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
            _httpClient.DefaultRequestHeaders.Add("Accept-Language", "da,en-US;q=0.7,en;q=0.3");
            _httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br, zstd");
            _httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            _httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
            _httpClient.DefaultRequestHeaders.Add("Host", "www.power.dk");
        }


        public async override Task<UnifiedProductDetails?> GetProductDetailsAsync(string sku)
        {

            string productUrl = $"https://www.power.dk/api/v2/products?ids={sku}";
            HttpResponseMessage response = await _httpClient.GetAsync(productUrl);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Could not load product details");
            }


            string jsonResponse = await response.DecompressAsStringAsync();
            PowerProductResponse productDetails = JsonConvert.DeserializeObject<List<PowerProductResponse>>(jsonResponse)[0];

            var image = new List<string>();
            image.Add($"https://www.power.dk{productDetails?.ProductImage?.BasePath}");
            image.Add($"https://www.power.dk{productDetails?.ProductImage?.Variants[0].Filename}");
            return new UnifiedProductDetails
            {
                Name = productDetails.Title,
                //Brand = productDetails.,
                Description = productDetails.ShortDescription,
                Gtin = productDetails.EanGtin12,
                Merchant = "Power",
                Price = productDetails.Price.ToString(),
                ImageUrls = image


            };
        }

        public async override IAsyncEnumerable<UnifiedProductPreview> GetProductsFromSearchAsync(string query)
        {
            //https://www.power.dk/api/v2/productlists?size=36&q=9800x3d&s=5&from=0&o=false

            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"https://www.power.dk/api/v2/productlists?size=36&q={Uri.EscapeDataString(query)}&s=5&from=0&o=false");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception("Could not search Power.");
            }

            string jsonString = await responseMessage.DecompressAsStringAsync();

            PowerSearchResponse powerResponse = JsonConvert.DeserializeObject<PowerSearchResponse>(jsonString);


            foreach (var product in powerResponse.Products)
            {
                yield return new UnifiedProductPreview
                {
                    Name = product.Title,
                    IdSku = product.ProductId.ToString(),
                    ImageUrl = $"https://www.power.dk{product.ProductImage?.BasePath}",
                    CurrentPrice = product.Price.ToString(),
                    Url = $"https://www.power.dk{product.Url}",
                    Merchant = "Power",


                };
            }

        }
    }
}
