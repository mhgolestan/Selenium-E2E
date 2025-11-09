using EATestFramework.Driver;
using EATestProject.Pages;
using OpenQA.Selenium;
using EATestProject.Model;

namespace EATestProject;

public class UnitTest1 : IDisposable
{
    readonly IWebDriver driver;
    private readonly IDriverFixture driverFixture;

    public UnitTest1(IDriverFixture driverFixture)
    {
        driver = driverFixture.Driver;
        driver.Navigate().GoToUrl(new Uri("http://localhost:8001/"));
        this.driverFixture = driverFixture;
    }

    public void Dispose()
    {
        driver.Quit();
    }

    [Fact]
    public void TestHomePage()
    {
        HomePage homePage = new HomePage(driverFixture);
        CreateProductPage createProductPage = new CreateProductPage(driverFixture);

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
