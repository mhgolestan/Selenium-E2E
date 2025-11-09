using Autofac;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumXUnitBasics.Driver;

namespace SeleniumXUnitBasics;

public class UnitTest2: IDisposable
{
    readonly IWebDriver driver;
    readonly IContainer container;

    public UnitTest2()
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<BrowserDriver>().As<IBrowserDriver>();
        container = builder.Build();
        var driverFixture = new DriverFixture(container, BrowserType.Firefox);
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
