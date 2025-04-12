using Pricely.Libraries.Shared.Models;

namespace Pricely.Core.Services.Merchants.CompuMail
{
    internal interface ICompuMailService : IMerchant
    {
        Task<UnifiedProductDetails?> GetProductDetailsAsync(string productUrl);
        IAsyncEnumerable<UnifiedProductPreview> GetProductsFromSearchAsync(string query);
    }
}