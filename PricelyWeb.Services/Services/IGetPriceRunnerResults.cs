using Pricely.Libraries.Services.Models.PriceRunner;

namespace Pricely.Libraries.Services.Services
{
    public interface IGetPriceRunnerResults
    {
        public Task<PriceRunnerSearchResults> GetProductsFromSearch(string search);
        public  Task<PriceRunnerProductDetails> GetProductDetailsFromId(string productId, string categoryId);
    }
}