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
using Pricely.Core.Services.Merchants.Proshop;
using Pricely.Libraries.Shared.Models;

namespace Pricely.Con.MerchantTests
{
   public static class MerchantManualTest
    {
        public static async Task TestGetProductSearchAndDetails()
        {
            HttpClient client = new();
            IMerchant service = new CompuMailService(client);

          

            //Console.WriteLine("Search TEST:");
            //List<UnifiedProductPreview> prodList = new();

            //await foreach (var item in service.GetProductsFromSearchAsync("iphone"))
            //{
            //    Console.WriteLine(item.Name);
            //    prodList.Add(item);
            //}

            //Console.WriteLine("");
            //Console.WriteLine("");
            //Console.WriteLine("Product Details TEST:");

            var product = await service.GetProductDetailsAsync("1003147208");
            Console.WriteLine($"{product.Name} - {product.Merchant} - {product.Description}");
        }
    }
}
