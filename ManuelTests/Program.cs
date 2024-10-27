using Newtonsoft.Json;
using PricelyAPI.ServiceModels.Elgiganten;
using PricelyAPI.ServiceModels.Pricerunner;
using System;
using System.Dynamic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

/*
Projektet her bliver kun brugt til at teste et par ting manuelt, inden de bliver implementeret.
Brugbare links:
https://jsonformatter.org/json-pretty-print
 https://json2csharp.com (Man kan også bruge Paste Special i Visual Studio)

Tree View for JSON:
https://codebeautify.org/jsonviewer

 */

public class Program
{
    public static async Task Main(string[] args)
    {
        var url = "https://www.elgiganten.dk/api/search"; 

        EGProductSearch payload = new("IpHOne 14");

        
        


        var jsonPayload = JsonConvert.SerializeObject(payload).ToString();

        using (var client = new HttpClient())
        {
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);

            var responseContent = await response.Content.ReadAsStringAsync();

            dynamic egSr = JsonConvert.DeserializeObject<dynamic>(responseContent);

            foreach (var product in egSr.data.records)
            {
                Console.WriteLine((string)product?.imageUrl + " - " + (string)product?.sellerName + " - " + (string)product?.price?.current[0] );
            }

     


        }
    }
}
