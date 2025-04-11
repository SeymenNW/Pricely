using Pricely.Core.Services.Merchants.Alternate;
using Pricely.Core.Services.Merchants.Elgiganten;
using Pricely.Libraries.Shared.ResponseModels.Alternate;

HttpClient client = new();
AlternateService service = new(client);


//await foreach (var item in service.GetProductsFromSearchAsync("9070"))
//{
//    Console.WriteLine(item.Name);
//}


var d = await service.GetProductDetailsAsync("https://www.alternate.dk/AMD/Ryzen-7-9800X3D-Processor/html/product/100093605");

Console.WriteLine(d.Name);
