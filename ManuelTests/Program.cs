//Her tester jeg lidt. Kan ikke rigtig bruges til meget.
using PricelyAPI.Services.PricerunnerService;


PricerunnerService prService = new();

var products = await prService.GetProductsFromSearch("PS5");

foreach (var item in products.ProductResults)
{
    Console.WriteLine(item.Name + " " + item.LowestPrice + $" ({item.LowestPrice})");

}

