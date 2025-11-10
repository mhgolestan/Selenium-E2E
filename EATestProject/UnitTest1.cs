using AutoFixture.Xunit2;
using EATestFramework.Driver;
using EATestProject.Model;
using EATestProject.Pages;
using OpenQA.Selenium;

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

    [Theory, AutoData]
    public void Test1(Product product)
    {

        homePage.CreateProduct();
        createProductPage.EnterProductDetails(product);
    }

    [Theory, AutoData]
    public void Test2(Product product)
    {

        homePage.CreateProduct();
        createProductPage.EnterProductDetails(product);
    }
}
