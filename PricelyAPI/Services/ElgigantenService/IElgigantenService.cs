using Pricely.Libraries.Services.Models.Elgiganten;

namespace PricelyAPI.Services.ElgigantenService
{
    public interface IElgigantenService
    {
        Task<ElgigantenSearchResults> GetProductsFromSearch(string search);
    }
}