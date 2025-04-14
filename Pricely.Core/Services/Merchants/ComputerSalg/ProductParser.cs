using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Pricely.Libraries.Shared.Models;

namespace Pricely.Core.Services.Merchants.ComputerSalg
{
    public static class ProductParser
    {
        public static UnifiedProductDetails ParseProduct(this IComputerSalgService compuSalg, string htmlContent)
        {
            var product = new UnifiedProductDetails();
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);

            var productNode = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'm-product-card')]")[0];

         
            product.Name = productNode.SelectSingleNode(".//h3[contains(@class, 'm-product-card__name')]")?
                .InnerText?.Trim();


            //product. = productNode.SelectSingleNode(".//a[contains(@class, 'm-product-card__see-product-cta')]")?
            //    .GetAttributeValue("href", null);


            //var imgNode = productNode.SelectSingleNode(".//img[contains(@class, 'a-image')]");
            //product.ImageUrls?.Add(imgNode?.GetAttributeValue("src", null).ToString() ??
            //                  imgNode?.GetAttributeValue("data-src", null).ToString());

            var priceNode = productNode.SelectSingleNode(".//span[contains(@class, 'm-product-card__price-text')]");
            product.Price = priceNode?.InnerText?.Trim();

            //var currencyNode = productNode.SelectSingleNode(".//span[contains(@class, 'm-product-card__currency')]");
            //product.Currency = currencyNode?.InnerText?.Trim();

            return product;
        }


    }
}

