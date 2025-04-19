using Pricely.Core.Services.Merchants;
using Pricely.Core.Services.Merchants.Alternate;
using Pricely.Core.Services.Merchants.CompuMail;
using Pricely.Core.Services.Merchants.ComputerSalg;
using Pricely.Core.Services.Merchants.Elgiganten;
using Pricely.Core.Services.Merchants.Føniks;
using Pricely.Core.Services.Merchants.Komplett;
using Pricely.Core.Services.Merchants.MaxGaming;
using Pricely.Core.Services.Merchants.Power;
using Pricely.Core.Services.Merchants.Proshop;
using Pricely.Server.Services.MultiSearch;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddHttpClient();

//Merchants:
builder.Services.AddTransient<IMerchant, AlternateService>();
builder.Services.AddTransient<IMerchant, CompuMailService>();
builder.Services.AddTransient<IMerchant, ComputerSalgService>();
builder.Services.AddTransient<IMerchant, ElgigantenService>();
builder.Services.AddTransient<IMerchant, FoniksService>();
builder.Services.AddTransient<IMerchant, KomplettService>();
builder.Services.AddTransient<IMerchant, MaxGamingService>();
builder.Services.AddTransient<IMerchant, PowerService>();
builder.Services.AddTransient<IMerchant, ProshopService>();

builder.Services.AddTransient<IMultiSearchService, MultiSearchService>();

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(op =>
    {
        op.WithTitle("Pricely API v2.0");
        op.WithTheme(ScalarTheme.BluePlanet);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
