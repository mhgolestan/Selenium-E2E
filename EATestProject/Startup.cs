using Microsoft.Extensions.DependencyInjection;
using EATestFramework.Driver;
using EATestProject.Pages;
using EATestFramework.Extensions;

namespace EATestProject;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.UseWebDriverInitializer();
        services.AddScoped<IDriverFixture, DriverFixture>();
        services.AddScoped<IBrowserDriver, BrowserDriver>();
        services.AddScoped<IHomePage, HomePage>();
        services.AddScoped<IProductPage, ProductPage>();
    }
}
