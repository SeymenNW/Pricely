using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Pricely.Core.Extensions;
using Pricely.Libraries.Shared.Models;
using Pricely.Libraries.Shared.ResponseModels.MaxGaming;
using Pricely.Libraries.Shared.ResponseModels.Proshop;

namespace Pricely.Core.Services.Merchants.MaxGaming
{
    public class MaxGamingService : Merchant, IMaxGamingService
    {

        private readonly HttpClient _httpClient;
        public MaxGamingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
            _httpClient.DefaultRequestHeaders.Add("Accept-Language", "da,en-US;q=0.7,en;q=0.3");
            _httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br, zstd");
            _httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            _httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
            _httpClient.DefaultRequestHeaders.Add("Host", "www.maxgaming.dk");
        }
        public override async Task<UnifiedProductDetails?> GetProductDetailsAsync(string id)
        {
            string productUrl = $"https://www.maxgaming.dk/sog?q={id}";
            HttpResponseMessage response = await _httpClient.GetAsync(productUrl);

            MaxGamingProductResponse product = await response.GetJsonLdFromHtmlAsync<MaxGamingProductResponse>("Product", "application/ld+json");

            List<string> images = new();
            images.Add(product.Image);
            return new UnifiedProductDetails
            {
                Name = product.Name,
                Gtin = product.Gtin8,
                Description = product.Description,
                Brand = product.Brand.Name,
                Merchant = "MaxGaming",
                ImageUrls = images,
                Price = product.Offers?.Price

            };
        }
        public override async IAsyncEnumerable<UnifiedProductPreview> GetProductsFromSearchAsync(string query)
        {
            string url = $"https://www.maxgaming.dk/sog?q={query}";


            HttpResponseMessage response;
            HttpClient client = new();

            response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Could not get Data");
            }

            string html = await response.DecompressAsStringAsync();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            var scriptNode = doc.DocumentNode
                .SelectSingleNode("//script[@type='text/javascript' and @consent_type='5']");

            if (scriptNode != null)
            {
                string scriptContent = scriptNode.InnerText;
                string correctedContent = scriptContent.Replace("  gtag(\"event\", \"view_item_list\", ", "");
                string fullContent = correctedContent.Replace(");", "");

                MaxGamingSearchResponse results = JsonConvert.DeserializeObject<MaxGamingSearchResponse>(fullContent);

                foreach (var item in results.Items)
                {

                    yield return new UnifiedProductPreview
                    {
                       Name = item.ItemName,
                       IdSku = item.ItemId,
                       CurrentPrice = item.Price.ToString(),
                       ImageUrl = "None.",
                       Url = $"https://www.maxgaming.dk/sog?q={item.ItemId}",
                       Merchant = "MaxGaming",
                     

                    }; 
                }

            }
        }
    }
}
