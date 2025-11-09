using OpenQA.Selenium;
using SeleniumXUnitBasics.Driver;
using Autofac;

namespace SeleniumXUnitBasics;

public class DriverFixture
{
    readonly IWebDriver driver;
    private readonly IContainer container;
    public DriverFixture(IContainer container, BrowserType browserType)
    {
        this.container = container;
        driver = GetWebDriver(browserType);
    }

    public IWebDriver Driver => driver;

    private IWebDriver GetWebDriver(BrowserType browserType)
    {
        var browserDriver = container.Resolve<IBrowserDriver>();
        return browserType switch
        {
            BrowserType.Chrome => browserDriver.GetChromeDriver(),
            BrowserType.Firefox => browserDriver.GetFirefoxDriver(),
            _ => browserDriver.GetChromeDriver(),
        };
    }
}
