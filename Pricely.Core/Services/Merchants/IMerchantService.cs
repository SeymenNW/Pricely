using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricely.Libraries.Shared.Models;

namespace Pricely.Core.Services.Merchants
{
    public interface IMerchantService
    {
       public IAsyncEnumerable<UnifiedProductPreview> GetProductsFromSearchAsync(string query);
    }
}
