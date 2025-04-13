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
    public class PowerService 
    {

        private readonly HttpClient _httpClient;
        public PowerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public  async Task<UnifiedProductDetails?> GetProductDetailsAsync(string sku)
        {
            string productUrl = $"https://www.power.dk/api/v2/products?ids={sku}";
            HttpResponseMessage response = await _httpClient.GetAsync(productUrl);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Could not load product details");
            }


            string jsonResponse = await response.DecompressAsStringAsync();
            PowerProductResponse productDetails = JsonConvert.DeserializeObject<PowerProductResponse>(jsonResponse);

            var image = new List<string>();
            image.Add(productDetails?.ProductImage?.BasePath);
            return new UnifiedProductDetails
            {
                Name = productDetails.Title,
                //Brand = productDetails.,
                Description = productDetails.ShortDescription,
                Gtin =  productDetails.EanGtin12,
                Merchant = "Power",
                Price = productDetails.Price.ToString(),
                ImageUrls = image


            };
        }

        public  IAsyncEnumerable<UnifiedProductPreview> GetProductsFromSearchAsync(string query)
        {
            throw new NotImplementedException();
        }
    }
}
