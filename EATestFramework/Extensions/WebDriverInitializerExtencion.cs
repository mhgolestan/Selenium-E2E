using EATestFramework.Driver;
using EATestFramework.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace EATestFramework.Extensions;

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
