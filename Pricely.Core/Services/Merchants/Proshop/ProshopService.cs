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

            ProshopProductDetails product = await response.GetJsonLdFromHtmlAsync<ProshopProductDetails>("Product", "application/ld+json");

            List<string> images = new();
            images.Add(product.Image);
            return new UnifiedProductDetails
            {
                Name = product.Name,
                Gtin = product.Gtin13,
                Description = product.Description,
                Brand = product.Brand.Name,
                Merchant = "Proshop",
                ImageUrls = images,
                Price = product.Offer.Price.ToString(),

            };
        }

        public override async IAsyncEnumerable<UnifiedProductPreview> GetProductsFromSearchAsync(string query)
        {
            string searchUrl = $"https://www.proshop.dk/ClientPlugins/AutoComplete/SearchResult?searchInput={Uri.EscapeDataString(query)}";

            HttpResponseMessage response = await _httpClient.GetAsync(searchUrl);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Could not get data from ProShop");
            }

            string htmlContent = await response.DecompressAsStringAsync();
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);

            
            HtmlNodeCollection productItems = htmlDoc.DocumentNode.SelectNodes("//li[contains(@class, 'site-customerCenterCard')]//a[contains(@class, 'search__item')]");

            if (productItems == null)
            {
                throw new Exception("No products found in search results.");
            }

            foreach (var item in productItems)
            {
                string productName = "";
                string productUrl = "";
                string productImageUrl = "";
                string productPrice = "";
                string productAvailability = "";

                // Product Name
                HtmlNode nameNode = item.SelectSingleNode(".//h3");
                if (nameNode != null)
                {
                    productName = nameNode.InnerText.Trim();
                }

                // Product URL
                productUrl = item.GetAttributeValue("href", "").Trim();
                if (!string.IsNullOrEmpty(productUrl) && !productUrl.StartsWith("http"))
                {
                    productUrl = "https://www.proshop.dk" + productUrl;
                }

                // Product Image
                HtmlNode imgNode = item.SelectSingleNode(".//img");
                if (imgNode != null)
                {
                    productImageUrl = imgNode.GetAttributeValue("src", "").Trim();
                    if (!string.IsNullOrEmpty(productImageUrl) && !productImageUrl.StartsWith("http"))
                    {
                        productImageUrl = "https://www.proshop.dk" + productImageUrl;
                    }
                }

                // Product Price
                HtmlNode priceNode = item.SelectSingleNode(".//span[contains(@class, 'has-presales-price')]")
                              ?? item.SelectSingleNode(".//h3[contains(@class, 'search__text')]");
                if (priceNode != null)
                {
                    productPrice = priceNode.InnerText.Trim();
                }

                // Product Availability
                HtmlNode availabilityNode = item.SelectSingleNode(".//div[contains(@class, 'site-stock-text')]");
                if (availabilityNode != null)
                {
                    productAvailability = availabilityNode.InnerText.Trim();
                }

                // id / sku
                string productSku = "";
                if (!string.IsNullOrEmpty(productUrl))
                {
                    string lastSegment = productUrl.Split('/').LastOrDefault();
                    if (!string.IsNullOrEmpty(lastSegment))
                    {
                        productSku = lastSegment.Split('?')[0]; 
                    }
                }

                yield return new UnifiedProductPreview
                {
                    Name = productName,
                    CurrentPrice = productPrice,
                    IdSku = productSku,
                    Url = productUrl,
                    ImageUrl = productImageUrl,
                    Merchant = "ProShop",

                    //And maybe 
                    //Availability = productAvailability,
                    
                    //soon ?
                };
            }
        }
    }
}
