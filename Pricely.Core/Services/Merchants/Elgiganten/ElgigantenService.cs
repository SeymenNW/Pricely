using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricely.Libraries.Shared.Models;

namespace Pricely.Core.Services.Merchants.Elgiganten
{
    public class ElgigantenService : IMerchantService
    {
        private readonly HttpClient _httpClient;
        public ElgigantenService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IAsyncEnumerable<UnifiedProductPreview>> GetProductsFromSearchAsync(string query)
        {
            throw new NotImplementedException();
        }
    }
}
