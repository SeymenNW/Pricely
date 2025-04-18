using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Pricely.Core.Services.Merchants.ComputerSalg;
using Pricely.Libraries.Shared.Models;

namespace Pricely.Core.Services.Merchants.Proshop
{
    public static class SearchHtmlParser
    {
        public static IEnumerable<UnifiedProductPreview> ParseProductsFromHtml(this IProshopService compuService, string htmlContent)
        {
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
                    productPrice = priceNode.InnerText.Trim().Replace("kr.", "").Replace(",00", "").Trim().Replace(".", "").Trim();
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
                    Image = productImageUrl,
                    Merchant = Libraries.Shared.Enums.MerchantEnum.Proshop,

                    //And maybe 
                    //Availability = productAvailability,

                    //soon ?
                };
            }
        }
    }
}

