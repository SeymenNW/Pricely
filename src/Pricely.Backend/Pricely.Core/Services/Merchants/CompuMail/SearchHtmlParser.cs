using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Pricely.Core.Services.Merchants.ComputerSalg;
using Pricely.Libraries.Shared.Models;

namespace Pricely.Core.Services.Merchants.CompuMail
{
    public static class SearchHtmlParser
    {
        public static IEnumerable<UnifiedProductPreview> ParseProductsFromHtml(this ICompuMailService compuService, string htmlContent)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);

            HtmlNodeCollection productItems = htmlDoc.DocumentNode.SelectNodes("//li[contains(@class, 'clearfix') and not(contains(@class, 'header'))]");


            if (productItems == null)
            {
                throw new Exception("Products are null");
            }

            foreach (var item in productItems)
            {
                UnifiedProductPreview product = new UnifiedProductPreview();
                HtmlNode productLink = item.SelectSingleNode(".//a[contains(@class, 'product-link')]");
                if (productLink == null) continue;

                product.Name = productLink.GetAttributeValue("data-product-name", "");
                product.IdSku = productLink.GetAttributeValue("data-product-id", "");
                //string brand = productLink.GetAttributeValue("data-product-brand", "");
                //string variant = productLink.GetAttributeValue("data-product-variant", "");

                // Images
                HtmlNode img = productLink.SelectSingleNode(".//img");
                product.Image = img?.GetAttributeValue("src", "");

                // Product URL
                string productUrl = productLink.GetAttributeValue("href", "");
                if (!string.IsNullOrEmpty(productUrl) && !productUrl.StartsWith("http"))
                {
                    product.Url = "https://www.compumail.dk" + productUrl;
                }

                // Price
                HtmlNode priceNode = item.SelectSingleNode(".//span[@class='price' and contains(@data-price, '')]");
                product.CurrentPrice = priceNode?.InnerText?.Trim().Replace("&nbsp;", "").Trim().Replace(",00", "").Trim();
                

                // Availability
                HtmlNode availabilityNode = item.SelectSingleNode(".//span[@class='pid' and contains(@style, 'display: inline')]");
                string availability = availabilityNode?.InnerText?.Trim();

                product.Merchant = Libraries.Shared.Enums.MerchantEnum.CompuMail;
                yield return product;
            }
        }
    }
}

