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
        var browserType = config.GetSection("BrowserType").Value; 
        services.UseWebDriverInitializer((BrowserType)(Enum.Parse(typeof(BrowserType), browserType, ignoreCase: true)));
        services.AddScoped<IDriverFixture, DriverFixture>();
        services.AddScoped<IBrowserDriver, BrowserDriver>();
        services.AddScoped<IHomePage, HomePage>();
        services.AddScoped<ICreateProductPage, CreateProductPage>();
    }
}
