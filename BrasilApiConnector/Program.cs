using BrasilApiConnector.Controllers;
using BrasilApiConnector.Infrastructure.Api;
using BrasilApiConnector.Infrastructure.Data;
using BrasilApiConnector.Interfaces;
using BrasilApiConnector.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", "Development");
var env = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production";

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
    .Build();

Console.WriteLine($"DOTNET_ENVIRONMENT = {Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}");
Console.WriteLine($"Connection string = {configuration.GetConnectionString("DefaultConnection")}");

var services = new ServiceCollection();
services.AddSingleton<IConfiguration>(configuration);

services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(
        configuration.GetConnectionString("DefaultConnection"),
        sql => sql.EnableRetryOnFailure(0)
    )
    .LogTo(Console.WriteLine, LogLevel.Information)
);

services.AddHttpClient<IApiClient, BrasilApiClient>();
services.AddScoped<ICepService, CepService>();
services.AddScoped<CepController>();

var provider = services.BuildServiceProvider();
var controller = provider.GetRequiredService<CepController>();


try
{
    await controller.RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao rodar controller: {ex.Message}");
}