using Pricely.Core.Services.Merchants;
using Pricely.Core.Services.Merchants.Alternate;
using Pricely.Core.Services.Merchants.Elgiganten;
using Pricely.Libraries.Shared.ResponseModels.Alternate;

HttpClient client = new();
IMerchantService service = new ElgigantenService(client);


//await foreach (var item in service.GetProductsFromSearchAsync("9070"))
//{
//    Console.WriteLine(item.Name);
//}


var d = await service.GetProductDetailsAsync("757597");




Console.WriteLine(d.Name);