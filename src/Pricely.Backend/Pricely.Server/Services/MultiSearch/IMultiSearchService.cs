using Pricely.Libraries.Shared.Models;

namespace Pricely.Server.Services.MultiSearch
{
    public interface IMultiSearchService
    {
        IAsyncEnumerable<UnifiedProductPreview> SearchProductsFromAllMerchantsAsync(string searchQuery);
    }
}