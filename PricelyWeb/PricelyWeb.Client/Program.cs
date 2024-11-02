using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using DotNetEnv;
using PricelyWeb.Services;
using Microsoft.Extensions.Logging;
using PricelyWeb.Services.PricelySettings;
using System.Net.Http.Json;

Env.Load();
var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Set up logging
builder.Logging.SetMinimumLevel(LogLevel.Debug);

var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
var settings = await httpClient.GetFromJsonAsync<PricelySettings>("/api/settings");
builder.Services.AddSingleton(settings);  // Register the fetched settings

// Initialize settings

//if (builder.HostEnvironment.IsDevelopment())
//{
//    string backendUrl = "https://localhost:7036";
//    settings.BackendUrl = backendUrl;
//}
//else if (builder.HostEnvironment.IsProduction())
//{
//    string backendUrl = "https://localhost:7036";
  
//    settings.BackendUrl = backendUrl;
//}

// Register services
builder.Services.AddSingleton(settings);
builder.Services.AddTransient<IGetPriceRunnerResults>(sp =>
{
    return new GetPriceRunnerResults(settings.BackendUrl);
});
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

await builder.Build().RunAsync();
