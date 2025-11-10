using Microsoft.Extensions.DependencyInjection;
using EATestFramework.Driver;
using EATestProject.Pages;
using EATestFramework.Extensions;
using Microsoft.Extensions.Configuration;

namespace EATestProject;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var browserTypeString = config.GetSection("BrowserType").Value;
        if (!Enum.TryParse<BrowserType>(browserTypeString, true, out var browserType))
        {
            throw new ArgumentException($"BrowserType '{browserTypeString}' in appsettings.json is not a supported browser.");
        }
        services.UseWebDriverInitializer(browserType);
        services.AddScoped<IDriverFixture, DriverFixture>();
        services.AddScoped<IBrowserDriver, BrowserDriver>();
        services.AddScoped<IHomePage, HomePage>();
        services.AddScoped<ICreateProductPage, CreateProductPage>();
    }
}
