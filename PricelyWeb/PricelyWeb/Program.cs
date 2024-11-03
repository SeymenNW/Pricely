using MudBlazor.Services;
using PricelyWeb.Client.Components.Home;
using PricelyWeb.Components;
using PricelyWeb.Services;
using PricelyWeb.Services.PricelySettings;


var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
DotNetEnv.Env.Load();
builder.Services.AddMudServices();
PricelySettings settings = PricelySettings.Instance;
if (builder.Environment.IsDevelopment())
{
    string backendUrl = "https://localhost:7036";
    settings.BackendUrl = backendUrl;
}
else if (builder.Environment.IsProduction())
{
    string backendUrl = Environment.GetEnvironmentVariable("BACKEND__URL");
    settings.BackendUrl = backendUrl;
}
builder.Services.AddSingleton(settings);

builder.Services.AddTransient<IGetPriceRunnerResults>(sp =>
{
    return new GetPriceRunnerResults("");
}); 
builder.Services.AddHttpClient();

    


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();
app.MapGet("/api/settings", (PricelySettings settings) => settings);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(PricelyWeb.Client._Imports).Assembly);

app.Run();
