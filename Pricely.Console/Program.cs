using Pricely.Core.Services.Merchants;
using Pricely.Core.Services.Merchants.Alternate;
using Pricely.Core.Services.Merchants.Elgiganten;
using Pricely.Libraries.Shared.ResponseModels.Alternate;

/*
 * This console application is being used for running manual tests. 
 */


HttpClient client = new();
IMerchant service = new ElgigantenService(client);


await foreach (var item in service.GetProductsFromSearchAsync("9070"))
{
    Console.WriteLine(item.Name);
}


