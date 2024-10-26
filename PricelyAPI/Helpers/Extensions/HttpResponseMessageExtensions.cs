using System.IO.Compression;

namespace PricelyAPI.Helpers.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<string> GetJsonString(this HttpResponseMessage httpResponseMsg)
        {
            //Pricerunner compresser med GZIP, Men denne metode inkluderer både GZip og Deflate decompression.
            if (httpResponseMsg.Content.Headers.ContentEncoding.Contains("gzip"))
            {
                using (var responseStream = await httpResponseMsg.Content.ReadAsStreamAsync())
                using (var decompressedStream = new GZipStream(responseStream, CompressionMode.Decompress))
                using (var reader = new StreamReader(decompressedStream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
            else if (httpResponseMsg.Content.Headers.ContentEncoding.Contains("deflate"))
            {
                using (var responseStream = await httpResponseMsg.Content.ReadAsStreamAsync())
                using (var decompressedStream = new DeflateStream(responseStream, CompressionMode.Decompress))
                using (var reader = new StreamReader(decompressedStream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
            else
            {
                //Hvis der ikke er noget compression eller encoding, bliver den bare læst som almindelig json.
                return await httpResponseMsg.Content.ReadAsStringAsync();
            }
        }
    }
}
