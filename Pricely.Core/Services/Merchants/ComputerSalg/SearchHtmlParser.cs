using HtmlAgilityPack;
using Pricely.Libraries.Shared.Enums;
using Pricely.Libraries.Shared.Models;

namespace Pricely.Core.Services.Merchants.ComputerSalg
{


    public static class SearchHtmlParser
    {
        public static IEnumerable<UnifiedProductPreview> ParseProductsFromHtml(this IComputerSalgService compuService, string htmlContent)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);

            var productNodes = htmlDoc.DocumentNode.SelectNodes("//li[contains(@class, 'o-search-dropdown__item')]");
            if (productNodes == null) yield break;

            foreach (var node in productNodes)
            {
                var product = new UnifiedProductPreview();

                //Name and URL
                var linkNode = node.SelectSingleNode(".//a[contains(@class, 'm-search-item')]");
                if (linkNode != null)
                {
                    product.Url = NormalizeUrl(linkNode.GetAttributeValue("href", ""));
                    product.Name = linkNode.SelectSingleNode(".//div[contains(@class, 'm-search-item__name')]")?
                        .InnerText.Trim();
                }

                //Image
                product.ImageUrl = node.SelectSingleNode(".//img")?.GetAttributeValue("src", "");

                //Price
                product.CurrentPrice = node.SelectSingleNode(".//div[contains(@class, 'm-search-item__price')]")?
                    .InnerText.Trim().Replace(",00","").Trim();

                //ID/SKU
                var statusNode = node.SelectSingleNode(".//div[contains(@class, 'm-search-item__status')]");
                if (statusNode != null)
                {
                    var parts = statusNode.InnerText.Split('|');
                    if (parts.Length > 0)
                        product.IdSku = parts[0].Replace("Varenr.", "").Trim().Trim('.', ':').Trim();
               
                }

                // Availability (Not needed but added for idk if i decide to add availability support sometime soon)
                //var stockNode = node.SelectSingleNode(".//span[contains(@class, 'stock')]");
                //if (stockNode != null)
                //{
                //    product.Availability = stockNode.ParentNode?.InnerText.Trim();
                //}
                product.Merchant = MerchantEnum.ComputerSalg;
                yield return product;
            }
        }

        private static string NormalizeUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) return "";
            return url.StartsWith("http") ? url : $"https://www.computersalg.dk{url}";
        }
    }
}
