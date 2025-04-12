using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Pricely.Core.Helper
{
    public static class HtmlData
    {
        public static async Task<List<string>> GetJsonLdAsync(string url)
        {
            List<string> result = new List<string>();

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);

            var jsonLdScripts = doc.DocumentNode
                .SelectNodes("//script[@type='application/ld+json']");

            if (jsonLdScripts != null)
            {
                foreach (var script in jsonLdScripts)
                {
                    var json = script.InnerText;
                    result.Add(json);
                }
            }


            return result;
        }


    }
}
