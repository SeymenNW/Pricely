using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Pricely.Libraries.Services.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddTransient<IGetPriceRunnerResults, GetPriceRunnerResults>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

await builder.Build().RunAsync();
