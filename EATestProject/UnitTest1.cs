using EATestFramework.Driver;
using EATestProject.Pages;
using OpenQA.Selenium;
using EATestProject.Model;

namespace EATestProject;

public class UnitTest1 : IDisposable
{
    readonly IWebDriver driver;
    private readonly IHomePage homePage;
    private readonly ICreateProductPage createProductPage;

    public UnitTest1(IDriverFixture driverFixture, IHomePage homePage, ICreateProductPage createProductPage)
    {
        driver = driverFixture.Driver;
        driver.Navigate().GoToUrl(new Uri("http://localhost:8001/"));
        this.homePage = homePage;
        this.createProductPage = createProductPage;
    }

    public void Dispose()
    {
        driver.Quit();
    }

    [Fact]
    public void Test1()
    {
        homePage.CreateProduct();
        createProductPage.EnterProductDetails(new Product
        {
            Name = "Table",
            Description = "Table Description",
            Price = 222,
            ProductType = ProductType.CPU,
        });

    }
}
