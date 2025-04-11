using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricely.Libraries.Shared.Models;

namespace Pricely.Core.Services.Merchants.Komplett
{
    public class KomplettService : Merchant, IKomplettService
    {
        public override Task<UnifiedProductDetails?> GetProductDetailsAsync(string productUrl)
        {
            throw new NotImplementedException();
        }

        public override IAsyncEnumerable<UnifiedProductPreview> GetProductsFromSearchAsync(string query)
        {
            throw new NotImplementedException();
        }
    }
}
