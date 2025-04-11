using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Pricely.Libraries.Shared.Models;

namespace Pricely.Core.Services.Merchants.Alternate
{
    public class AlternateService : IAlternateService
    {
        private readonly HttpClient _httpClient;

        public AlternateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async IAsyncEnumerable<UnifiedProductPreview> GetProductsFromSearchAsync(string query)
        {

            //query needs to be fixed
            string alternateUrl = $"https://www.alternate.dk/listing.xhtml?q={query}";

            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
            _httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
            _httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            _httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");

            HttpResponseMessage response = await _httpClient.GetAsync(alternateUrl);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Could not get data from Alternate");
            }

            string htmlContent = await DecompressResponseAsync(response);

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

                //Product Variant (Could be colors for example or amount of RAM idk)
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

                //// Product Details - Not Implemented yet.
                //var infoList = card.SelectNodes(".//ul[contains(@class, 'product-info')]/li");
                //if (infoList != null)
                //{
                //    List<string> details = new List<string>();
                //    foreach (var li in infoList)
                //    {
                //        details.Add(li.InnerText.Trim());
                //    }
                //    product["details"] = string.Join(", ", details);
                //}


                yield return new UnifiedProductPreview
                {
                    Name = productBrand + " " + productName,
                    CurrentPrice = productPrice,
                    IdSku = "",
                    Url = productUrl,
                    ImageUrl = productImageUrl,
                    Merchant = "Alternate"
                };

            }
        }


        private async Task<string> DecompressResponseAsync(HttpResponseMessage response)
        {
            string contentEncoding = response.Content.Headers.ContentEncoding.ToString();
            Stream contentStream = await response.Content.ReadAsStreamAsync();

            if (contentEncoding.Contains("gzip"))
            {
                using var decompressedStream = new GZipStream(contentStream, CompressionMode.Decompress);
                using var reader = new StreamReader(decompressedStream, Encoding.UTF8);
                return await reader.ReadToEndAsync();
            }
            else if (contentEncoding.Contains("deflate"))
            {
                using var decompressedStream = new DeflateStream(contentStream, CompressionMode.Decompress);
                using var reader = new StreamReader(decompressedStream, Encoding.UTF8);
                return await reader.ReadToEndAsync();
            }
            else
            {
                using var reader = new StreamReader(contentStream, Encoding.UTF8);
                return await reader.ReadToEndAsync();
            }
        }
    }
}
