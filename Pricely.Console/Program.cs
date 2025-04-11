using Pricely.Core.Services.Merchants.Alternate;
using Pricely.Core.Services.Merchants.Elgiganten;
using Pricely.Libraries.Shared.ResponseModels.Alternate;

HttpClient client = new();
AlternateService service = new(client);


//await foreach (var item in service.GetProductsFromSearchAsync("9070"))
//{
//    Console.WriteLine(item.Name);
//}


var d = await service.GetProductDetailsAsync("1288807");

await foreach (var item in service.GetProductsFromSearchAsync("9070"))
{
    Console.WriteLine(item.IdSku + " "+ item.Name);
}


Console.WriteLine(d.Name);