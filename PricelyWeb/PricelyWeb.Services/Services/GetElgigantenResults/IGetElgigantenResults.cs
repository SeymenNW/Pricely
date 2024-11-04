using Pricely.Libraries.Shared.Models;

namespace PricelyWeb.Services
{
    public interface IGetElgigantenResults
    {
        Task<ElgigantenSearchResults> GetProductsFromSearch(string search);
    }
}