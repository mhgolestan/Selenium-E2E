using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductAPI.Data;
using ProductAPI.Repository;


namespace EATestBDD;

public static class Startup
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();
        var projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new string[] { @"bin/" },
                                StringSplitOptions.None)[0];
        
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        IConfigurationRoot configuration = new ConfigurationBuilder()
                                        .SetBasePath(projectPath)
                                        .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                                        .AddEnvironmentVariables()
                                        .Build();
        string connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ProductDbContext>(option => option
                    .UseSqlServer(connectionString + ";TrustServerCertificate=True;"));
        
        services.AddTransient<IProductRepository, ProductRepository>();
        services.UseWebDriverInitializer();
        services.AddScoped<IDriverFixture, DriverFixture>();
        services.AddScoped<IBrowserDriver, BrowserDriver>();
        services.AddScoped<IHomePage, HomePage>();
        services.AddScoped<IProductPage, ProductPage>();
        return services;
    }
}
