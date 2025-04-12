using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Pricely.Core.Extensions;
using Pricely.Libraries.Shared.Models;
using Pricely.Libraries.Shared.ResponseModels.CompuMail;
using Pricely.Libraries.Shared.ResponseModels.Elgiganten;
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

        public async override IAsyncEnumerable<UnifiedProductPreview> GetProductsFromSearchAsync(string query)
        {
            string url = $"https://www.compumail.dk/da/quicksearch?q={Uri.EscapeDataString(query)}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Could not load product details");
            }


            string jsonResponse = await response.DecompressAsStringAsync();
            CompuMailSearchResponse searchResponse = JsonConvert.DeserializeObject<CompuMailSearchResponse>(jsonResponse);

          
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(searchResponse.Html.ProductsHtml);

            var productItems = htmlDoc.DocumentNode.SelectNodes("//li[contains(@class, 'clearfix') and not(contains(@class, 'header'))]");


            if (productItems == null)
            {
                throw new Exception("Products are null");
            }

            foreach (var item in productItems)
            {
               
                var productLink = item.SelectSingleNode(".//a[contains(@class, 'product-link')]");
                if (productLink == null) continue;

                var name = productLink.GetAttributeValue("data-product-name", "");
                var id = productLink.GetAttributeValue("data-product-id", "");
                var brand = productLink.GetAttributeValue("data-product-brand", "");
                var variant = productLink.GetAttributeValue("data-product-variant", "");

                // Images
                var img = productLink.SelectSingleNode(".//img");
                var imageUrl = img?.GetAttributeValue("src", "");

                // Product URL
                var productUrl = productLink.GetAttributeValue("href", "");
                if (!string.IsNullOrEmpty(productUrl) && !productUrl.StartsWith("http"))
                {
                    productUrl = "https://www.compumail.dk" + productUrl;
                }

                // Price
                var priceNode = item.SelectSingleNode(".//span[@class='price' and contains(@data-price, '')]");
                var price = priceNode?.InnerText?.Trim();

                // Availability
                var availabilityNode = item.SelectSingleNode(".//span[@class='pid' and contains(@style, 'display: inline')]");
                var availability = availabilityNode?.InnerText?.Trim();

                // Filter
                if (!string.IsNullOrEmpty(query) &&
                    !name.Contains(query, StringComparison.OrdinalIgnoreCase) &&
                    !brand.Contains(query, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }



                yield return new UnifiedProductPreview
                {
                    Name = name,
                    CurrentPrice = price,
                    IdSku = id,
                    Url = productUrl,
                    ImageUrl = imageUrl,
                    Merchant = "CompuMail",
                    //Availability = availability

                };

             
            }

        }
    }
}
