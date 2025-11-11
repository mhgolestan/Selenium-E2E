using EATestBDD.Pages;
using EATestFramework.Driver;
using EATestFramework.Extensions;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;

namespace EATestBDD;

public static class Startup
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();

        services.UseWebDriverInitializer();
        services.AddScoped<IDriverFixture, DriverFixture>();
        services.AddScoped<IBrowserDriver, BrowserDriver>();
        services.AddScoped<IHomePage, HomePage>();
        services.AddScoped<IProductPage, ProductPage>();
        return services;
    }
}
