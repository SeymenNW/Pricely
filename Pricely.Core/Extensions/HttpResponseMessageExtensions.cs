using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pricely.Core.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<string> DecodeAsStringAsync(this HttpResponseMessage httpResponseMsg)
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
    }
}
