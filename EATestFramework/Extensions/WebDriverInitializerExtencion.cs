using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using EATestFramework.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace EATestFramework.Extensions;

public static class WebDriverInitializerExtencion
{
    public static IServiceCollection UseWebDriverInitializer(this IServiceCollection services)
    {
        services.AddSingleton(ReadConfig());
        return services;
    }

    private static TestSettings ReadConfig()
    {
        var configFile = File.ReadAllText(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            + "/appsettings.json");
        var jsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };
        jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        var testSettings = JsonSerializer.Deserialize<TestSettings>(configFile, jsonSerializerOptions);
        return testSettings;
    }

}
