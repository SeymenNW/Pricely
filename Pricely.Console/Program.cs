using Pricely.Core.Services.Merchants.Alternate;
using Pricely.Core.Services.Merchants.Elgiganten;

HttpClient client = new();
AlternateService service = new(client);

// Fix: Add 'await' and make the containing method asynchronous.
await foreach (var product in service.GetProductsFromSearchAsync("9070"))
{
    // Process each product (if needed)
    Console.WriteLine(product.Name);
}