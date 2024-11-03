

using Pricely.Libraries.Shared.Models;

namespace PricelyAPI.Services.MerchantServices.PriceRunnerService
{
    public interface IPriceRunnerService
    {
        Task<PriceRunnerSearchResults> GetProductsFromSearch(string search);
        Task<PriceRunnerProductDetails> GetProductDetailsFromId(string productId, string productCategoryNum);
    }
}