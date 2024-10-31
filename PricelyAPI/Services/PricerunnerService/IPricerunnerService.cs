using Pricely.Libraries.Services.Models.PriceRunner;
using PricelyAPI.ServiceModels.Pricerunner;

namespace PricelyAPI.Services.PricerunnerService
{
    public interface IPriceRunnerService
    {
        Task<PriceRunnerSearchResults> GetProductsFromSearch(string search);
        Task<PriceRunnerProductDetails> GetProductDetailsFromId(string productId, string productCategoryNum);
    }
}