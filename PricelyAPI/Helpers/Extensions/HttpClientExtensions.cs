using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace PricelyAPI.Helpers.Extensions
{
    public static class HttpClientExtensions
    {
        public static void AddHeaders(this HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/130.0.0.0 Safari/537.36");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json"); 
            httpClient.DefaultRequestHeaders.Add("Accept-Language", "da-DK,da;q=0.9,en-US;q=0.8,en;q=0.7");
            httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br, zstd"); 
        }

   

  
    }
}
