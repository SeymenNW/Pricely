using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pricely.Core.Extensions;
using Pricely.Libraries.Shared.Models;
using Pricely.Libraries.Shared.ResponseModels.CompuMail;
using Pricely.Libraries.Shared.ResponseModels.Foniks;

namespace Pricely.Core.Services.Merchants.Føniks
{
   public class FoniksService : Merchant, IFoniksService
    {

        private readonly HttpClient _httpClient;

        public FoniksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("Host", "www.fcomputer.dk");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:137.0) Gecko/20100101 Firefox/137.0");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json, text/javascript, */*; q=0.01");
            _httpClient.DefaultRequestHeaders.Add("Accept-Language", "da,en-US;q=0.7,en;q=0.3");
            _httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br, zstd");
            _httpClient.DefaultRequestHeaders.Add("Origin", "https://www.fcomputer.dk");
            _httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
            _httpClient.DefaultRequestHeaders.Add("Referer", $"https://www.fcomputer.dk/search");
            _httpClient.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
            _httpClient.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
            _httpClient.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
            _httpClient.DefaultRequestHeaders.Add("TE", "trailers");
        }

        public override async Task<UnifiedProductDetails?> GetProductDetailsAsync(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://www.fcomputer.dk/{url}");

            if (!response.IsSuccessStatusCode)
            {
               
                throw new Exception("Failed to load Price Data from CompuMail.");
            }

            FoniksProductResponse product = await response.GetJsonLdFromHtmlAsync<FoniksProductResponse>("Product", "application/ld+json");

            return new UnifiedProductDetails
            {
                Name = product.Name,
                Price = product?.Offers?.Price,
                Description = product?.Description,
                ImageUrls = product?.Images,
                Gtin = product?.Gtin14,
                Merchant = Libraries.Shared.Enums.MerchantEnum.Føniks,
                Brand = "Not Specified"
            };
        }


        public async override IAsyncEnumerable<UnifiedProductPreview> GetProductsFromSearchAsync(string query)
        {
            FormUrlEncodedContent payload = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("query", query) });
            HttpResponseMessage response = await _httpClient.PostAsync("https://www.fcomputer.dk/json/search/query", payload);

            if (!response.IsSuccessStatusCode)
            {
                yield break;
                //throw new Exception("Could not get data from Føniks");
            }

            string responseJson = await response.DecompressAsStringAsync();

            FoniksSearchResponse foniks = JsonConvert.DeserializeObject<FoniksSearchResponse>(responseJson);

            if (foniks?.Content?.Results?.Categories == null || foniks.Content.Results.Categories.Count == 0)
                yield break;


            foreach (Category category in foniks.Content.Results.Categories)
            {
                foreach (Product product in category.Products)
                {
                    yield return new UnifiedProductPreview
                    {
                        Name = product.Title,
                        IdSku = product.Url,
                        Url = $"https://www.fcomputer.dk/{product.Url}",
                        CurrentPrice = product.Price.ToString(),
                        ImageUrl = product.Photo,
                        Merchant = Libraries.Shared.Enums.MerchantEnum.Føniks,
                    };
                }
            }

        }
    }
}
