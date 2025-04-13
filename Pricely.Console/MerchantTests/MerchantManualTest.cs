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
using Pricely.Core.Services.Merchants.Power;
using Pricely.Core.Services.Merchants.Proshop;
using Pricely.Libraries.Shared.Models;

namespace Pricely.Con.MerchantTests
{
    public static class MerchantManualTest
    {
        public static async Task TestGetProductSearchAndDetails()
        {
            HttpClient client = new();

            Type interfaceType = typeof(IMerchant);
            List<Type> results = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => interfaceType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                .ToList();


            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {results[i].Name}");
            }

            Console.Write("\nChoose a service by number: ");
            if (int.TryParse(Console.ReadLine(), out int choice) &&
                choice >= 1 && choice <= results.Count)
            {
                Type selectedType = results[choice - 1];
                IMerchant service = (IMerchant)Activator.CreateInstance(selectedType, client);

                Console.Clear();
                Console.WriteLine($"CHOSEN SERVICE: {selectedType.Name}");
                Console.WriteLine("1: PRODUCT SEARCH ONLY");
                Console.WriteLine("2: PRODUCT DETAILS ONLY");
                Console.WriteLine("3: PRODUCT SEARCH & DETAILS");
                int chosenOption = int.Parse(Console.ReadLine());
                List<UnifiedProductPreview> prodList = new();
                if (chosenOption == 1 || chosenOption == 3)
                {
                    Console.Clear();
                    Console.Write("ENTER SEARCH:");
                    string searchQuery = Console.ReadLine();
                    int x = 1;
                    await foreach (var item in service.GetProductsFromSearchAsync(searchQuery))
                    {
                        Console.WriteLine($"{x}: {item.Name} - {item.CurrentPrice} - {item.Url} ({item.IdSku})");
                        Console.WriteLine("");

                        prodList.Add(item);
                        x++;
                    }
                }
                 if (chosenOption == 2 || chosenOption == 3)
                {
                    var firstProd = prodList.FirstOrDefault();

                    string details = chosenOption == 3  ?  firstProd.IdSku : Console.ReadLine();

                    Console.WriteLine("");
                    Console.WriteLine("PRODUCT DETAILS (For Testing):");

                    var product = await service.GetProductDetailsAsync(details);
                    Console.WriteLine($"{product.Name}");
                    //Console.WriteLine($"{product.Merchant}");
                    Console.WriteLine($"{product.Price}");
                    Console.WriteLine($"{product.ImageUrls[0]}");
                }



             

            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }


    }
}

