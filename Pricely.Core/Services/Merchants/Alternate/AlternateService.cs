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

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);

            var productCards = htmlDoc.DocumentNode.SelectNodes("//a[contains(@class, 'productBox')]");
            List<Dictionary<string, string>> products = new List<Dictionary<string, string>>();

            if (productCards == null)
            {
                throw new Exception("No products found.");
            }

            foreach (var card in productCards)
            {
                string productName = "";
                string productBrand = "";
                string productVariant = "";
                string productUrl = "";
                string productImageUrl = "";
                string productPrice = "";
                string productAvailaibility = "";
                List<string> productDetails = new List<string>();

                //Product Name & Brand.
                var nameDiv = card.SelectSingleNode(".//div[contains(@class, 'product-name')]");
                if (nameDiv != null)
                {
                    var brandSpan = nameDiv.SelectSingleNode(".//span");
                    if (brandSpan != null)
                    {
                        productBrand = brandSpan.InnerText.Trim();
                        brandSpan.Remove();
                    }
                    productName = nameDiv.InnerText.Trim();
                }

                //Product Variant
                var nameSub = card.SelectSingleNode(".//span[contains(@class, 'product-name-sub')]");
                if (nameSub != null)
                {
                    productVariant = nameSub.InnerText.Trim();
                }

                //Product Url
                productUrl = card.GetAttributeValue("href", "").Trim();

                //Product Image Url
                var img = card.SelectSingleNode(".//img[contains(@class, 'productPicture')]");
                if (img != null)
                {
                    productImageUrl = img.GetAttributeValue("src", "").Trim();
                }

                //Product Price
                var priceSpan = card.SelectSingleNode(".//span[contains(@class, 'price')]");
                if (priceSpan != null)
                {
                    productPrice = priceSpan.InnerText.Trim();
                }

                //Product Availability
                var deliveryInfo = card.SelectSingleNode(".//div[contains(@class, 'delivery-info')]");
                if (deliveryInfo != null)
                {
                    productAvailaibility = deliveryInfo.InnerText.Trim();
                }

                //// Product Details
                var infoList = card.SelectNodes(".//ul[contains(@class, 'product-info')]/li");
                if (infoList != null)
                {
                    List<string> details = new List<string>();
                    foreach (var li in infoList)
                    {
                        details.Add(li.InnerText.Trim());
                    }
                    productDetails = details;
                }
                string productSku = productUrl.Substring(productUrl.LastIndexOf('/') + 1);


                yield return new UnifiedProductPreview
                {
                    Name = $"{productBrand} {productName} {productDetails[0]}",
                    CurrentPrice = productPrice,
                    IdSku = productSku,
                    Url = productUrl,
                    ImageUrl = productImageUrl,
                    Merchant = "Alternate"
                };

            }
        }

        public override async Task<UnifiedProductDetails?> GetProductDetailsAsync(string id)
        {
            string productUrl = $"https://www.alternate.dk/api/product/{id}";
            HttpResponseMessage response = await _httpClient.GetAsync(productUrl);

            AlternateProductSchema product = await response.GetJsonLdFromHtmlAsync<AlternateProductSchema>("Product", "application/ld+json");

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
