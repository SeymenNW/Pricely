using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Pricely.Core.Services.Merchants.ComputerSalg;
using Pricely.Libraries.Shared.Models;

namespace Pricely.Core.Services.Merchants.Alternate
{
    public static class SearchHtmlParser
    {
        public static IEnumerable<UnifiedProductPreview> ParseProductsFromHtml(this IAlternateService compuService, string htmlContent)
        {

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);

            HtmlNodeCollection productCards = htmlDoc.DocumentNode.SelectNodes("//a[contains(@class, 'productBox')]");
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
                HtmlNode nameDiv = card.SelectSingleNode(".//div[contains(@class, 'product-name')]");
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
                HtmlNode nameSub = card.SelectSingleNode(".//span[contains(@class, 'product-name-sub')]");
                if (nameSub != null)
                {
                    productVariant = nameSub.InnerText.Trim();
                }

                //Product Url
                productUrl = card.GetAttributeValue("href", "").Trim();

                //Product Image Url
                HtmlNode img = card.SelectSingleNode(".//img[contains(@class, 'productPicture')]");
                if (img != null)
                {
                    productImageUrl = img.GetAttributeValue("src", "").Trim();
                }

                //Product Price
                HtmlNode priceSpan = card.SelectSingleNode(".//span[contains(@class, 'price')]");
                if (priceSpan != null)
                {
                    productPrice = priceSpan.InnerText.Trim().Replace("kr.", "").Trim().Replace(".","").Trim().Replace(",00","");
                }

                //Product Availability
                HtmlNode deliveryInfo = card.SelectSingleNode(".//div[contains(@class, 'delivery-info')]");
                if (deliveryInfo != null)
                {
                    productAvailaibility = deliveryInfo.InnerText.Trim();
                }

                //// Product Details
                HtmlNodeCollection infoList = card.SelectNodes(".//ul[contains(@class, 'product-info')]/li");
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
                    Merchant = Libraries.Shared.Enums.MerchantEnum.Alternate
                };

            }

        }
    }
}
