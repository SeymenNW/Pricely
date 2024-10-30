using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Pricely.Libraries.Services.Services;
using PricelyWeb.Client.Configuration;
using DotNetEnv;

Env.Load();
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddTransient<IGetPriceRunnerResults, GetPriceRunnerResults>();



PricelySettings settings = new();
if (builder.HostEnvironment.IsDevelopment())
{
    settings.BackendUrl = "https://localhost:7036";
}
else if (builder.HostEnvironment.IsProduction())
{
    settings.BackendUrl = Environment.GetEnvironmentVariable("BACKEND__URL");
}

builder.Services.AddSingleton(settings);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();



await builder.Build().RunAsync();
