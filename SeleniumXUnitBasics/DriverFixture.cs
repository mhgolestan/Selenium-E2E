using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumXUnitBasics;

public class DriverFixture : IDisposable
{
    readonly ChromeDriver driver;
    public DriverFixture()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        driver = new ChromeDriver();
    }

    public ChromeDriver GetWebDriver() => driver;

    public void Dispose()
    {
        driver.Quit();
        GC.SuppressFinalize(this);
    }
}
