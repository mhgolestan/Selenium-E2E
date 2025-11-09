using OpenQA.Selenium;

namespace SeleniumXUnitBasics.Driver;


public interface IDriverFixture
{
    IWebDriver Driver { get; }
}
