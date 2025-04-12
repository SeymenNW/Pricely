using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricely.Libraries.Shared.Models;

namespace Pricely.Core.Services.Merchants
{
    public abstract class Merchant : IMerchant
    {

        


        public abstract Task<UnifiedProductDetails?> GetProductDetailsAsync(string productUrl);

        public abstract IAsyncEnumerable<UnifiedProductPreview> GetProductsFromSearchAsync(string query);


    }
}
