//using System.Net.Http;
//using HtmlAgilityPack;
//using Pricely.Con.MerchantTests;
//using Pricely.Core.Extensions;
//using Pricely.Libraries.Shared.ResponseModels.Alternate;

//internal class Program
//{
//    private static async Task Main(string[] args)
//    {
//        string url = "https://www.maxgaming.dk/sog?q=arctis";


//        HttpResponseMessage response;
//        HttpClient client = new();

//        response = await client.GetAsync(url);
//        string html = await response.DecompressAsStringAsync();
//        HtmlDocument doc = new HtmlDocument();
//        doc.LoadHtml(html);

//        var scriptNode = doc.DocumentNode
//            .SelectSingleNode("//script[@type='text/javascript' and @consent_type='5']");

//        if (scriptNode != null)
//        {
//            string scriptContent = scriptNode.InnerText;
//            Console.WriteLine(scriptContent);
//        }

//    }
//}
