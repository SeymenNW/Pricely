using PricelyAPI.ServiceModels.Pricerunner;

namespace PricelyAPI.Services.PricerunnerService
{
    public interface IPricerunnerService
    {
        Task<PricerunnerProductSearch> GetProductsFromSearch(string search);
    }
}