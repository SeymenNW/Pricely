using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricely.Core.Services.Merchants;
using Pricely.Core.Services.Merchants.Alternate;
using Pricely.Core.Services.Merchants.CompuMail;
using Pricely.Core.Services.Merchants.Elgiganten;
using Pricely.Core.Services.Merchants.Komplett;
using Pricely.Core.Services.Merchants.MaxGaming;
using Pricely.Core.Services.Merchants.Proshop;
using Pricely.Libraries.Shared.Models;

namespace Pricely.Con.MerchantTests
{
   public static class MerchantManualTest
    {
        public static async Task TestGetProductSearchAndDetails()
        {
            HttpClient client = new();
            IMerchant service = new MaxGamingService(client);



            Console.WriteLine("SEARCH RESULTS (For Testing):");
            List<UnifiedProductPreview> prodList = new();
            int i = 0;
            await foreach (var item in service.GetProductsFromSearchAsync("headset"))
            {
                Console.WriteLine($"{i}: {item.Name} - {item.CurrentPrice} - {item.Url}");
                Console.WriteLine("");

                prodList.Add(item);
                i++;
            }

            Console.WriteLine("");
            Console.WriteLine("PRODUCT DETAILS (For Testing):");

            var product = await service.GetProductDetailsAsync(prodList[0].IdSku);
            Console.WriteLine($"{product.Name}");
            //Console.WriteLine($"{product.Merchant}");
            Console.WriteLine($"{product.Price}");
            Console.WriteLine($"{product.ImageUrls[0]}");
        }
    }
}
