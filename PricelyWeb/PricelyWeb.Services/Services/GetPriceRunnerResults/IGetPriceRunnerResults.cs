using Pricely.Libraries.Shared.Models;

namespace PricelyWeb.Services
{
    public interface IGetPriceRunnerResults
    {
        public Task<PriceRunnerSearchResults> GetProductsFromSearch(string search);
        public Task<PriceRunnerProductDetails> GetProductDetailsFromId(string productId, string categoryId);
    }
}