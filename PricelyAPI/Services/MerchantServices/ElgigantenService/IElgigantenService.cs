
using Pricely.Libraries.Shared.Models;

namespace PricelyAPI.Services.MerchantServices.ElgigantenService
{
    public interface IElgigantenService
    {
        Task<ElgigantenSearchResults> GetProductsFromSearch(string search);
    }
}