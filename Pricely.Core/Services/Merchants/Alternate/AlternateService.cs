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
            string alternateUrl = $"https://www.alternate.dk/search-suggestions.xhtml?q={query}";

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

            var suggestions = htmlDoc.DocumentNode.SelectNodes("//a[contains(@class, 'suggest-entry')]");
            if (suggestions == null)
            {
                throw new Exception("No suggestions found.");
            }

            foreach (var suggestion in suggestions)
            {
                string productName = suggestion.InnerText.Trim();
                string productLink = suggestion.GetAttributeValue("href", string.Empty);
                string rawPrice = suggestion.SelectSingleNode(".//span[contains(@class, 'suggest-price')]")?.InnerText?.Trim() ?? "";
                string productPrice = Regex.Replace(rawPrice, @"[^\d,.-]", ""); // Remove "kr" and keep only numbers
                string imageUrl = suggestion.SelectSingleNode(".//img")?.GetAttributeValue("src", string.Empty) ?? "";

                yield return new UnifiedProductPreview
                {
                    Name = productName,
                    CurrentPrice = productPrice,
                    IdSku = "",
                    Url = productLink,
                    ImageUrl = imageUrl,
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
