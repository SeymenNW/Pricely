//Her tester jeg lidt. Kan ikke rigtig bruges til meget.
using PricelyAPI.Services.PricerunnerService;


PriceRunnerService prService = new();

var products = await prService.GetProductDetailsFromId("3331926710");

//var merchantId = products.Merchants[products.Offers[0].MerchantId].Name;
//var offerId = products.Offers[0].MerchantId;

foreach (var item in products.ImageUrls)
{
    Console.WriteLine(item);
}
