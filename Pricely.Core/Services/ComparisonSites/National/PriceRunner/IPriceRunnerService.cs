using Pricely.Libraries.Shared.Models;

namespace Pricely.Core.Services.ComparisonSites.National.PriceRunner
{
    public interface IPriceRunnerService
    {
        Task<PriceRunnerProductDetails> GetProductDetailsFromId(string productId, string productCategoryNum);
        Task<PriceRunnerSearchResults> GetProductsFromSearch(string search);
    }
}