using System;
using Microsoft.Extensions.DependencyInjection;
using EATestFramework.Driver;

namespace EATestFramework;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.UseWebDriverInitializer(BrowserType.Firefox);
        services.AddScoped<IDriverFixture, DriverFixture>();
        services.AddScoped<IBrowserDriver, BrowserDriver>();
    }
}
