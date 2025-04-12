using System.Net.Http;
using HtmlAgilityPack;
using Pricely.Con.MerchantTests;
using Pricely.Core.Extensions;
using Pricely.Libraries.Shared.ResponseModels.Alternate;

internal class Program
{
    private static async Task Main(string[] args)
    {
       await MerchantManualTest.TestGetProductSearchAndDetails();

    }
}
