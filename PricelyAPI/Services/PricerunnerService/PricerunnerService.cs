using Newtonsoft.Json;
using PricelyAPI.ServiceModels.Pricerunner;
using System.IO.Compression;

namespace PricelyAPI.Services.PricerunnerService
{
    public class PricerunnerService : IPricerunnerService
    {

        //Eksempel Søgning: https://www.pricerunner.dk/dk/api/search-compare-gateway/public/search/suggest/DK?q=iPhone
        //V2: https://www.pricerunner.dk/dk/api/search-compare-gateway/public/search/v5/DK?q=IPHONE&suggestionsActive=true&suggestionClicked=false&suggestionReverted=false&carouselSize=10
        public async Task<PricerunnerProductSearch> GetProductsFromSearch(string search)
        {
            string searchToUrl = search.Replace(" ", "%20");

            string prSearchUrl = $"https://www.pricerunner.dk/dk/api/search-compare-gateway/public/search/v5/DK?q={searchToUrl}&suggestionsActive=true&suggestionClicked=false&suggestionReverted=false&carouselSize=10";

            var jsonSettings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };

            using (HttpClient httpClient = new())
            {
                try
                {
                    // Set the headers for the request
                    httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json"); // Set to accept JSON response
                    httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
                    httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate"); // Accept gzip and deflate

                    HttpRequestMessage httpRequestMsg = new(HttpMethod.Get, prSearchUrl);
                    HttpResponseMessage httpResponseMsg = await httpClient.SendAsync(httpRequestMsg);
                    httpResponseMsg.EnsureSuccessStatusCode();

                    string jsonString;

                    //Pricerunner compresser med GZIP, Men denne metode inkluderer både GZip og Deflate.
                    if (httpResponseMsg.Content.Headers.ContentEncoding.Contains("gzip"))
                    {
                        using (var responseStream = await httpResponseMsg.Content.ReadAsStreamAsync())
                        using (var decompressedStream = new GZipStream(responseStream, CompressionMode.Decompress))
                        using (var reader = new StreamReader(decompressedStream))
                        {
                            jsonString = await reader.ReadToEndAsync();
                        }
                    }
                    else if (httpResponseMsg.Content.Headers.ContentEncoding.Contains("deflate"))
                    {
                        using (var responseStream = await httpResponseMsg.Content.ReadAsStreamAsync())
                        using (var decompressedStream = new DeflateStream(responseStream, CompressionMode.Decompress))
                        using (var reader = new StreamReader(decompressedStream))
                        {
                            jsonString = await reader.ReadToEndAsync();
                        }
                    }
                    else
                    {
                        // Read the response as is if no encoding
                        jsonString = await httpResponseMsg.Content.ReadAsStringAsync();
                    }

                    PricerunnerProductSearch prSearch = JsonConvert.DeserializeObject<PricerunnerProductSearch>(jsonString, jsonSettings);
                    return prSearch;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Fejl, kan ikke hente data. {e.Message}");
                    return null;
                }
            }
        }

        private async Task GetProductDetails(string productUrl)
        {

        }



    }
}
