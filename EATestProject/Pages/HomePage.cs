using EATestFramework.Driver;
using OpenQA.Selenium;

namespace EATestProject.Pages;

public interface IHomePage
{
    void CreateProduct();
}

public class HomePage : IHomePage
{
    private readonly IWebDriver driver;
    public HomePage(IDriverFixture driverFixture) => driver = driverFixture.Driver;
    IWebElement lnkProduct => driver.FindElement(By.LinkText("Product"));
    IWebElement lnkCreate => driver.FindElement(By.LinkText("Create"));

    public void CreateProduct()
    {
        lnkProduct.Click();
        lnkCreate.Click();
    }
}
