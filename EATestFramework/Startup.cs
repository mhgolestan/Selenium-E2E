using Microsoft.Extensions.DependencyInjection;
using EATestFramework.Driver;
using EATestFramework.Extensions;

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
