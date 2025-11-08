using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumXUnitBasics;

public class UnitTest1
{
    IWebDriver driver;
    [Fact]
    public void Test1()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        driver = new ChromeDriver();

        driver.Navigate().GoToUrl(new Uri("http://localhost:8001/"));
        driver.FindElement(By.LinkText("Product")).Click();
        driver.FindElement(By.LinkText("Create")).Click();
        driver.FindElement(By.Id("Name")).SendKeys("Table");
        driver.FindElement(By.Id("Description")).SendKeys("Table Description");
        driver.FindElement(By.Id("Price")).SendKeys("100");
        var select = new SelectElement(driver.FindElement(By.Id("ProductType")));
        select.SelectByValue("0");
        driver.FindElement(By.Id("Create")).Click();
        
        driver.Quit();
        driver.Dispose();
    }
}
