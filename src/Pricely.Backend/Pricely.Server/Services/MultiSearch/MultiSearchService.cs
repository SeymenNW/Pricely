using Pricely.Core.Services.Merchants;
using Pricely.Libraries.Shared.Models;

namespace Pricely.Server.Services.MultiSearch
{
    public class MultiSearchService : IMultiSearchService
    {
        private readonly IEnumerable<IMerchant> _merchants;

        public MultiSearchService(IEnumerable<IMerchant> merchants)
        {
            _merchants = merchants.Where(merchant => !merchant.GetType().IsAbstract);
        }

        public async IAsyncEnumerable<UnifiedProductPreview> SearchProductsFromAllMerchantsAsync(string searchQuery)
        {
            foreach (var merchant in _merchants)
            {
                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3)); 
                CancellationToken token = cts.Token;

               
                    await foreach (UnifiedProductPreview product in merchant.GetProductsFromSearchAsync(searchQuery).WithCancellation(token))
                    {
                    
                        yield return product;
                        cts.CancelAfter(TimeSpan.FromSeconds(3)); 
                    }
                }
                
            }
        }
    }


