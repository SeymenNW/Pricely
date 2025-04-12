using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

namespace Pricely.Core.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<string> DecompressAsStringAsync(this HttpResponseMessage httpResponseMsg)
        {
            var encodingHeaders = httpResponseMsg.Content.Headers.ContentEncoding;

            using (var responseStream = await httpResponseMsg.Content.ReadAsStreamAsync())
            {
                Stream decompressedStream = responseStream;

                if (encodingHeaders.Contains("gzip"))
                {
                    decompressedStream = new GZipStream(responseStream, CompressionMode.Decompress);
                }
                else if (encodingHeaders.Contains("deflate"))
                {
                    decompressedStream = new DeflateStream(responseStream, CompressionMode.Decompress);
                }
                else if (encodingHeaders.Contains("br"))
                {
                    decompressedStream = new BrotliStream(responseStream, CompressionMode.Decompress);
                }
              

                using (var reader = new StreamReader(decompressedStream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }

        public static async Task<T> GetJsonLdFromHtmlAsync<T>(this HttpResponseMessage response, string jType)
        {
            string html = await response.DecompressAsStringAsync();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            var scriptNodes = doc.DocumentNode.SelectNodes("//script[@type='application/ld+json']");
            if (scriptNodes == null || scriptNodes.Count == 0)
                return default;

            string firstScript = scriptNodes.First().InnerText?.Trim();
            if (string.IsNullOrWhiteSpace(firstScript))
                return default;

            var json = JToken.Parse(firstScript);

            T? result = default;

            if (json is JArray array)
            {
                foreach (var item in array)
                {
                    var type = item[$"@type"]?.ToString();
                    if (type == jType)
                    {
                        result = item.ToObject<T>();
                    }
                 
                }
            }
            else if (json is JObject obj)
            {
                var type = obj[$"@type"]?.ToString();
                if (type == jType)
                    result = obj.ToObject<T>();
         
            }

            return result;
        }

        //public static async Task<(TProduct? Product, TBreadcrumbs? Breadcrumbs)> GetBreadcrumbsJsonLdFromHtmlAsync<TProduct, TBreadcrumbs>(this HttpResponseMessage response)
        //{
        //    string html = await response.Content.ReadAsStringAsync();
        //    HtmlDocument doc = new HtmlDocument();
        //    doc.LoadHtml(html);

        //    var scriptNodes = doc.DocumentNode.SelectNodes("//script[@type='application/ld+json']");
        //    if (scriptNodes == null || scriptNodes.Count == 0)
        //        return (default, default);

        //    string firstScript = scriptNodes.First().InnerText?.Trim();
        //    if (string.IsNullOrWhiteSpace(firstScript))
        //        return (default, default);

        //    var json = JToken.Parse(firstScript);

        //    TProduct? product = default;
        //    TBreadcrumbs? breadcrumbs = default;

        //    if (json is JArray array)
        //    {
        //        foreach (var item in array)
        //        {
        //            var type = item["@type"]?.ToString();
        //            if (type == "Product")
        //            {
        //                product = item.ToObject<TProduct>();
        //            }
        //            else if (type == "BreadcrumbList")
        //            {
        //                breadcrumbs = item.ToObject<TBreadcrumbs>();
        //            }
        //        }
        //    }
        //    else if (json is JObject obj)
        //    {
        //        var type = obj["@type"]?.ToString();
        //        if (type == "Product")
        //            product = obj.ToObject<TProduct>();
        //        else if (type == "BreadcrumbList")
        //            breadcrumbs = obj.ToObject<TBreadcrumbs>();
        //    }

        //    return (product, breadcrumbs);
        //}


    }
}
