using OpenQA.Selenium;
using SeleniumXUnitBasics.Driver;

namespace SeleniumXUnitBasics;

public class DriverFixture
{
    readonly IWebDriver driver;
    public DriverFixture(BrowserType browserType)
    {
        driver = GetWebDriver(browserType);
    }

    public IWebDriver Driver => driver;

    private IWebDriver GetWebDriver(BrowserType browserType)
    {
        BrowserDriver browserDriver = new BrowserDriver();
        return browserType switch
        {
            BrowserType.Chrome => browserDriver.GetChromeDriver(),
            BrowserType.Firefox => browserDriver.GetFirefoxDriver(),
            _ => browserDriver.GetChromeDriver(),
        };
    }
}
