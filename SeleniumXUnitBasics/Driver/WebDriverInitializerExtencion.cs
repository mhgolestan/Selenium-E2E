using System;
using Microsoft.Extensions.DependencyInjection;
using SeleniumXUnitBasics.Settings;

namespace SeleniumXUnitBasics.Driver;

public static class WebDriverInitializerExtencion
{
    public static IServiceCollection UseWebDriverInitializer(
        this IServiceCollection services,
        BrowserType browserType)
    {
        services.AddSingleton(new TestSettings
        {
            browserType = browserType
        });
        return services;
    }



}
