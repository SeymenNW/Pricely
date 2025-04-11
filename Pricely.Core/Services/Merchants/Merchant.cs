using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricely.Libraries.Shared.Models;

namespace Pricely.Core.Services.Merchants
{
    public class Merchant : IMerchantService
    {
        public virtual IAsyncEnumerable<UnifiedProductPreview> GetProductsFromSearchAsync(string query)
        {
            throw new NotImplementedException("Implement in Derived Class.");
        }



        //This breaks SOLID yes, but will be moved soon.
        internal async Task<string> DecompressResponseAsync(HttpResponseMessage response)
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
