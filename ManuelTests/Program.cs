//Her tester jeg lidt. Kan ikke rigtig bruges til meget.
using PricelyAPI.Services.PricerunnerService;


PricerunnerService prService = new();

var product = await prService.GetProductsFromSearch("PS5");

Console.WriteLine(product.Products[0].LowestPrice.Amount);
