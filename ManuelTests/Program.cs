using Newtonsoft.Json;
using PricelyAPI.ServiceModels.Elgiganten;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

/*
 Projektet her bliver kun brugt til at teste et par ting manuelt, inden de bliver implementeret.
Brugbare links:
https://jsonformatter.org/json-pretty-print
 https://json2csharp.com (Man kan også bruge Paste Special i Visual Studio)

 */

public class Program
{
    public static async Task Main(string[] args)
    {
        var url = "https://www.elgiganten.dk/api/search"; 

        EGProductSearch payload = new("iPhone 13");



        var jsonPayload = JsonConvert.SerializeObject(payload).ToString();

        using (var client = new HttpClient())
        {
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);

            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);
        }
    }
}
