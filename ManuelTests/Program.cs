using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

public class RedirectExample
{
    public static async Task Main(string[] args)
    {
        var originalUrl = "https://www.pricerunner.dk/dk/api/search-compare-gateway/gotostore/v1/DK/be2c34f405440ab76ef658e6987c635f?productId=3211644574"; // Replace with your URL
        var (finalUrl, statusCode) = await GetFinalUrlAsync(originalUrl);
        Console.WriteLine($"Final URL: {finalUrl}, Status Code: {statusCode}");
    }

    public static async Task<(string FinalUrl, HttpStatusCode StatusCode)> GetFinalUrlAsync(string url)
    {
        using var httpClient = new HttpClient(new HttpClientHandler { AllowAutoRedirect = true });

        // Send the request
        var response = await httpClient.GetAsync(url);

        // Wait for 1 second to ensure the page has loaded (if necessary)
        await Task.Delay(1000);

        // Get the final URL and the status code
        string finalUrl = response.RequestMessage.RequestUri.ToString();
        HttpStatusCode statusCode = response.StatusCode;

        return (finalUrl, statusCode);
    }
}
