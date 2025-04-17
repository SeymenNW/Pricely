using System.Net.Http;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Pricely.Con.MerchantTests;
using Pricely.Core.Extensions;
using Pricely.Libraries.Shared.ResponseModels.Alternate;
using Pricely.Libraries.Shared.ResponseModels.MaxGaming;

internal class Program
{
    private static async Task Main(string[] args)
    {

       await MerchantManualTest.TestAll();
                

    }
}
