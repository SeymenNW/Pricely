using Asp.Versioning;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using PricelyAPI.Services.ElgigantenService;
using PricelyAPI.Services.PricerunnerService;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IPriceRunnerService, PriceRunnerService>();
builder.Services.AddTransient<IElgigantenService, ElgigantenService>();

builder.Services.AddCors(o => o.AddPolicy("EZPolicy", builder =>
{
    builder.AllowAnyOrigin()  
           .AllowAnyMethod()  
           .AllowAnyHeader(); 
}));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApiVersioning(options =>
{
    // Indstillinger for API Version
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;

    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
    options.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver"));
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});




builder.Services.AddSwaggerGen(
    options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Pricely API",
        Description = "Dette er den første version af Pricely API. Du kan selv bruge det i dine egne applikationer.\nI den første periode her vil der nok komme nogle ændringer.",
    });

    //options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
    //{
    //    Version = "v1",
    //    Title = "Pricely API",
    //    Description = "Ikke udkommet endnu",
    //});




}
);


var app = builder.Build();


app.UseCors("EZPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Pricely API v1");
       
        // options.SwaggerEndpoint("/swagger/v2/swagger.json", "Pricely API v2");
    });


}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
