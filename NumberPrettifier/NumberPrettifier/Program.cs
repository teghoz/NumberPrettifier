using BenchmarkDotNet.Running;
using Prettifier;
using Prettifier.Factories;
using Prettifier.Interfaces;
using Prettifier.Locales.en;
using Prettifier.Locales.fr;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IPrettifierDictionary, EnglishPrettyDictionary>();
builder.Services.AddSingleton<IPrettifierDictionary, FrenchPrettyDictionary>();

builder.Services.AddSingleton<IPrettifier, AbbreviatedPrettifier>();
builder.Services.AddSingleton<IPrettifier, FullWordPrettifier>();
builder.Services.AddSingleton<IPrettifier, FrenchFullWordPrettifier>();

builder.Services.AddSingleton<IPrettifierServiceFactory, PrettifierFactory>();
builder.Services.AddSingleton<IPrettifierDictionaryServiceFactory, PrettifierDictionaryFactory>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var summary = BenchmarkRunner.Run<AbbreviatedPrettifier>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
