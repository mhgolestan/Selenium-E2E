using OpenQA.Selenium;
using SeleniumXUnitBasics.Driver;

namespace SeleniumXUnitBasics;

public interface IDriverFixture
{
    IWebDriver Driver { get; }
}

public class DriverFixture : IDriverFixture
{
    readonly IWebDriver driver;
    private readonly IBrowserDriver browserDriver;

    public DriverFixture(IBrowserDriver browserDriver)
    {
        this.browserDriver = browserDriver;
        driver = GetWebDriver();
    }

    public IWebDriver Driver => driver;

    private IWebDriver GetWebDriver(BrowserType browserType = BrowserType.Chrome)
    {
        return browserType switch
        {
            BrowserType.Chrome => browserDriver.GetChromeDriver(),
            BrowserType.Firefox => browserDriver.GetFirefoxDriver(),
            _ => browserDriver.GetChromeDriver(),
        };
    }
}
