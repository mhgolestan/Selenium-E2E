using EATestFramework.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace EATestFramework.Driver;

public static class WebDriverInitializerExtencion
{
    public static IServiceCollection UseWebDriverInitializer(
                this IServiceCollection services,
                BrowserType browserType
        )
    {
        services.AddSingleton(new TestSettings
        {
            BrowserType = browserType
        });
        return services;
    }



}
