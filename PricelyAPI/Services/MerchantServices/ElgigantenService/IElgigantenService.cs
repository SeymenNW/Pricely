using Pricely.Libraries.Services.Models.Elgiganten;

namespace PricelyAPI.Services.MerchantServices.ElgigantenService
{
    public interface IElgigantenService
    {
        Task<ElgigantenSearchResults> GetProductsFromSearch(string search);
    }
}