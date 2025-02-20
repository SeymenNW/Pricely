using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using DotNetEnv;
using PricelyWeb.Services;
using Microsoft.Extensions.Logging;
using PricelyWeb.Services.PricelySettings;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;

Env.Load();
var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Logging.SetMinimumLevel(LogLevel.Debug);
builder.Services.AddBlazoredLocalStorage();

var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
var localStorage = builder.Services.BuildServiceProvider().GetRequiredService<ILocalStorageService>();

PricelySettings settings = new();

builder.Services.AddSingleton(settings);


//if (builder.HostEnvironment.IsProduction() && )
//{
    settings.BackendUrl = await localStorage.GetItemAsync<string>("apiUrl");
//}


builder.Services.AddSingleton(settings);
builder.Services.AddTransient<IGetPriceRunnerResults>(sp =>
{
    return new GetPriceRunnerResults(settings.BackendUrl);
});

builder.Services.AddTransient<IGetElgigantenResults>(sp =>
{
    return new GetElgigantenResults(settings.BackendUrl);
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

await builder.Build().RunAsync();
