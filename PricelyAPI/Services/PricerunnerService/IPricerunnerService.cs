using Pricely.Libraries.Services.Models;
using PricelyAPI.ServiceModels.Pricerunner;

namespace PricelyAPI.Services.PricerunnerService
{
    public interface IPricerunnerService
    {
        Task<PricerunnerSearchResults> GetProductsFromSearch(string search);
    }
}