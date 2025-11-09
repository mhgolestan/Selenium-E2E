using OpenQA.Selenium;

namespace SeleniumXUnitBasics.Driver;

public interface IBrowserDriver
{
    IWebDriver GetChromeDriver();
    IWebDriver GetFirefoxDriver();
}
