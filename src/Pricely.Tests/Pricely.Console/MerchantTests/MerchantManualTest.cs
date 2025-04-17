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
                    Console.Write("ENTER SEARCH: ");
                    string searchQuery = Console.ReadLine();
                    int x = 1;

                    Console.WriteLine($"\n{"#",-3} {"Name",-30} {"Price",-10} {"URL",-50} {"ID",-15}");
                    Console.WriteLine(new string('-', 110));

                    await foreach (var item in service.GetProductsFromSearchAsync(searchQuery))
                    {
                        Console.WriteLine($"{x,-3} {item.Name,-30} {item.CurrentPrice,-10} {item.Url,-50} {item.IdSku,-15}");
                        prodList.Add(item);
                        x++;
                    }

                    if (prodList.Count == 0)
                    {
                        Console.WriteLine("No products found.");
                    }
                }

                if (chosenOption == 2 || chosenOption == 3)
                {
                    var firstProd = prodList.FirstOrDefault();

                    Console.WriteLine("\nEnter product ID for details:");
                    string details = chosenOption == 3 && firstProd != null ? firstProd.IdSku : Console.ReadLine();

                    Console.WriteLine("\nPRODUCT DETAILS (For Testing):");
                    var product = await service.GetProductDetailsAsync(details);

                    if (product != null)
                    {
                        Console.WriteLine($"Name: {product.Name}");
                        Console.WriteLine($"Price: {product.Price}");
                        Console.WriteLine($"Brand: {product.Brand}");
                        Console.WriteLine($"Description: {product.Description}");
                        Console.WriteLine($"Image URL: {product.ImageUrls?.FirstOrDefault()}");
                    }
                    else
                    {
                        Console.WriteLine("No product details found.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        public static async Task TestAll()
        {
            Type interfaceType = typeof(IMerchant);
            List<Type> results = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => interfaceType.IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                .ToList();

            Console.Write("ENTER SEARCH QUERY: ");
            string searchQuery = Console.ReadLine();

            foreach (Type merchantType in results)
            {
                HttpClient client = new();

                Console.WriteLine($"\nRunning search for merchant: {merchantType.Name}");
                IMerchant service = (IMerchant)Activator.CreateInstance(merchantType, client);

                try
                {
                    int x = 1;

                    Console.WriteLine($"\n{"#",-3} {"Name",-30} {"Price",-10} {"URL",-50} {"ID",-15}");
                    Console.WriteLine(new string('-', 110));

                    await foreach (var item in service.GetProductsFromSearchAsync(searchQuery))
                    {
                        Console.WriteLine($"{x,-3} {item.Name,-30} {item.CurrentPrice,-10} {item.Url,-50} {item.IdSku,-15}");
                        x++;
                    }

                    if (x == 1)
                    {
                        Console.WriteLine("No products found for this merchant.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while searching with {merchantType.Name}: {ex.Message}");
                }
            }
        }
    }
}