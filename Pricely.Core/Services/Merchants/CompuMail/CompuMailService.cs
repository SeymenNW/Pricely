using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pricely.Core.Extensions;
using Pricely.Libraries.Shared.Models;
using Pricely.Libraries.Shared.ResponseModels.CompuMail;
using Pricely.Libraries.Shared.ResponseModels.Komplett;
using Pricely.Libraries.Shared.ResponseModels.Proshop;

namespace Pricely.Core.Services.Merchants.CompuMail
{
    public class CompuMailService : Merchant, ICompuMailService
    {

        private readonly HttpClient _httpClient;
        public CompuMailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
            _httpClient.DefaultRequestHeaders.Add("Accept-Language", "da,en-US;q=0.7,en;q=0.3");
            _httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br, zstd");
            _httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            _httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
            _httpClient.DefaultRequestHeaders.Add("Host", "www.compumail.dk");
        }

        public override async Task<UnifiedProductDetails?> GetProductDetailsAsync(string sku)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://www.compumail.dk/da/p/{sku}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to load Price Data from Komplett.");
            }


            CompuMailProductDetails product = await response.GetJsonLdFromHtmlAsync<CompuMailProductDetails>("Product");

            


            return new UnifiedProductDetails
            {
                Name = product.Name,
                Price = product.Offer?.Price,
                Description = product.Description,
                ImageUrls = product.Images,
                Gtin = "0",
                Merchant = "CompuMail",
                Brand = "Not Specified"
            };
        }

        public  override IAsyncEnumerable<UnifiedProductPreview> GetProductsFromSearchAsync(string query)
        {
            throw new NotImplementedException();
        }
    }
}
