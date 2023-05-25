using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Representative.Weathers.WebApi.Host.Configurations;
using Representative.Weathers.WebApi.Host.Filters;
using Representatives.Weathers.WebApi.Infrastructure.Caches;
using Representatives.Weathers.WebApi.Infrastructure.Clients.MeteoClient;
using Representatives.Weathers.WebApi.Infrastructure.Services;
using Representatives.Weathers.WebApi.Infrastructure.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// and slugify route
builder.Services.AddControllersWithViews(options =>
{
    options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
    options.Filters.Add(new ExceptionFilter());
});

// Add classes to dependency injection
builder.Services.AddSingleton(builder.Configuration.GetSection("Cache").Get<CacheSetting>());
builder.Services.AddHttpClient<IMeteoClient, MeteoClient>((client) =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("MeteoApi:BaseUrl"));
});
builder.Services.AddScoped<IStationCache, StationCache>();
builder.Services.AddScoped<IStationService, StationService>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.ConfigureSwagger();

string allowSpecificOrigins = "MainSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:44464" );
                      });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(allowSpecificOrigins);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
