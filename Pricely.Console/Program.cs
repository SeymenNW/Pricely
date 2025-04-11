using Pricely.Core.Services.Merchants.Alternate;
using Pricely.Core.Services.Merchants.Elgiganten;
using Pricely.Libraries.Shared.ResponseModels.Alternate;

HttpClient client = new();
AlternateService service = new(client);




var (product, breadcrumbs) = await service.GetProductDetailsAsync("https://www.alternate.dk/ICY-BOX/IB-1817M-C31-SSD-kabinet-Gr%C3%A5-M-2-Drev-kabinet/html/product/1522324");

Console.WriteLine(product.Name);
Console.WriteLine(breadcrumbs.ItemListElement[5].Item.Name);
