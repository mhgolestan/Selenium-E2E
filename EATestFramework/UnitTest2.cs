using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EATestFramework.Driver;

namespace EATestFramework;

public class UnitTest2: IDisposable
{
    readonly IWebDriver driver;

    public UnitTest2(IDriverFixture driverFixture)
    {
        driver = driverFixture.Driver;
        driver.Navigate().GoToUrl(new Uri("http://localhost:8001/"));
    }

    public void Dispose()
    {
        driver.Quit();
    }

    [Fact]
    public void Test1()
    {
        driver.FindElement(By.LinkText("Product")).Click();
        driver.FindElement(By.LinkText("Create")).Click();
        driver.FindElement(By.Id("Name")).SendKeys("Table");
        driver.FindElement(By.Id("Description")).SendKeys("Table Description");
        driver.FindElement(By.Id("Price")).SendKeys("100");
        var select = new SelectElement(driver.FindElement(By.Id("ProductType")));
        select.SelectByValue("0");
        driver.FindElement(By.Id("Create")).Click();
    }
    [Fact]
    public void Test2()
    {
        driver.FindElement(By.LinkText("Product")).Click();
        driver.FindElement(By.LinkText("Create")).Click();
        driver.FindElement(By.Id("Name")).SendKeys("Table");
        driver.FindElement(By.Id("Description")).SendKeys("Table Description");
        driver.FindElement(By.Id("Price")).SendKeys("100");
        var select = new SelectElement(driver.FindElement(By.Id("ProductType")));
        select.SelectByValue("0");
        driver.FindElement(By.Id("Create")).Click();
    }
    [Fact]
    public void Test3()
    {
        driver.FindElement(By.LinkText("Product")).Click();
        driver.FindElement(By.LinkText("Create")).Click();
        driver.FindElement(By.Id("Name")).SendKeys("Table");
        driver.FindElement(By.Id("Description")).SendKeys("Table Description");
        driver.FindElement(By.Id("Price")).SendKeys("100");
        var select = new SelectElement(driver.FindElement(By.Id("ProductType")));
        select.SelectByValue("0");
        driver.FindElement(By.Id("Create")).Click();
    }
}
