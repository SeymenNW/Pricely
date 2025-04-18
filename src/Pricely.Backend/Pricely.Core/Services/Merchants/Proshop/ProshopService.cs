using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Pricely.Core.Extensions;
using Pricely.Libraries.Shared.Models;
using Pricely.Libraries.Shared.ResponseModels.Alternate;
using Pricely.Libraries.Shared.ResponseModels.Proshop;

namespace Pricely.Core.Services.Merchants.Proshop
{
    public class ProshopService : Merchant, IProshopService
    {

        private readonly HttpClient _httpClient;
        public ProshopService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
            _httpClient.DefaultRequestHeaders.Add("Accept-Language", "da,en-US;q=0.7,en;q=0.3");
            _httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br, zstd");
            _httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            _httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
            _httpClient.DefaultRequestHeaders.Add("Host", "www.proshop.dk");
        }

        public override async Task<UnifiedProductDetails?> GetProductDetailsAsync(string id)
        {
            string productUrl = $"https://www.proshop.dk/{id}";
            HttpResponseMessage response = await _httpClient.GetAsync(productUrl);

            ProshopProductResponse product = await response.GetJsonLdFromHtmlAsync<ProshopProductResponse>("Product", "application/ld+json");

            List<string> images = new();
            images.Add(product.Image);
            return new UnifiedProductDetails
            {
                Name = product.Name,
                Gtin = product.Gtin13,
                Description = product.Description,
                Brand = product.Brand.Name,
                Merchant = Libraries.Shared.Enums.MerchantEnum.Power,
                Images = images,
                Price = product.Offer.Price.ToString(),

            };
        }

        public override async IAsyncEnumerable<UnifiedProductPreview> GetProductsFromSearchAsync(string query)
        {
            string searchUrl = $"https://www.proshop.dk/ClientPlugins/AutoComplete/SearchResult?searchInput={Uri.EscapeDataString(query)}";

            HttpResponseMessage response = await _httpClient.GetAsync(searchUrl);

            if (!response.IsSuccessStatusCode)
            {
                yield break;
                //throw new Exception("Could not get data from ProShop");
            }

            string htmlContent = await response.DecompressAsStringAsync();
            var productsList = this.ParseProductsFromHtml(htmlContent);

            if (productsList == null || !productsList.Any())
            {
                yield break;
            }

            foreach (UnifiedProductPreview product in productsList)
            {
                yield return product;
            }

        }
    }
}
