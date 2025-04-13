using System.IO.Compression;
using System.Text;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using Pricely.Core.Extensions;
using Pricely.Libraries.Shared.Models;
using Pricely.Libraries.Shared.ResponseModels.Alternate;

namespace Pricely.Core.Services.Merchants.Alternate
{


    public class AlternateService : Merchant, IAlternateService
    {
        private readonly HttpClient _httpClient;

        public AlternateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
            _httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
            _httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            _httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
        }

        public override async IAsyncEnumerable<UnifiedProductPreview> GetProductsFromSearchAsync(string query)
        {

            //query needs to be fixed
            string alternateUrl = $"https://www.alternate.dk/listing.xhtml?q={query.Replace(" ", "+")}";



            HttpResponseMessage response = await _httpClient.GetAsync(alternateUrl);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Could not get data from Alternate");
            }

            string htmlContent = await response.DecompressAsStringAsync();

            foreach (var product in this.ParseProductsFromHtml(htmlContent))
            {
                yield return product;
            }
        }

        public override async Task<UnifiedProductDetails?> GetProductDetailsAsync(string id)
        {
            string productUrl = $"https://www.alternate.dk/api/product/{id}";
            HttpResponseMessage response = await _httpClient.GetAsync(productUrl);

            AlternateProductResponse product = await response.GetJsonLdFromHtmlAsync<AlternateProductResponse>("Product", "application/ld+json");

            List<string> images = new();
            images.Add(product.Image);
            return new UnifiedProductDetails
            {
                Name = product.Name,
                Gtin = product.Gtin8,
                Description = product.Description,
                Brand = product.Brand.Name,
                Merchant = "Alternate",
                ImageUrls = images,
                Price = product.Offers.Price

            };
        }
    }
}
