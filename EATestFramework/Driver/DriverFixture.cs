using OpenQA.Selenium;
using EATestFramework.Settings;

namespace EATestFramework.Driver;

public class DriverFixture : IDriverFixture, IDisposable
{
    readonly IWebDriver driver;
    private readonly TestSettings testSettings;
    private readonly IBrowserDriver browserDriver;

    public DriverFixture(TestSettings testSettings, IBrowserDriver browserDriver)
    {
        this.testSettings = testSettings;
        this.browserDriver = browserDriver;
        driver = GetWebDriver();
        driver.Navigate().GoToUrl(testSettings.ApplicationUri);
    }

    public IWebDriver Driver => driver;

    public void Dispose()
    {
        driver.Quit();
    }

    private IWebDriver GetWebDriver()
    {
        return testSettings.BrowserType switch
        {
            BrowserType.Chrome => browserDriver.GetChromeDriver(),
            BrowserType.Firefox => browserDriver.GetFirefoxDriver(),
            _ => browserDriver.GetChromeDriver(),
        };
    }
}
