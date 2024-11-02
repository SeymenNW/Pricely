using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using DotNetEnv;
using PricelyWeb.Client.Configuration;
using PricelyWeb.Services;

Env.Load();
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddTransient<IGetPriceRunnerResults, GetPriceRunnerResults>();


PricelySettings settings = new();
if (builder.HostEnvironment.IsDevelopment())
{
    string backendUrl = "https://localhost:7036";
    settings.BackendUrl = backendUrl;
}
else if (builder.HostEnvironment.IsProduction())
{
    string backendUrl = Environment.GetEnvironmentVariable("BACKEND__URL");
    settings.BackendUrl = backendUrl;
}
builder.Services.AddSingleton(settings);

builder.Services.AddTransient<IGetPriceRunnerResults>(sp =>
{
    return new GetPriceRunnerResults(settings.BackendUrl);
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();



await builder.Build().RunAsync();
