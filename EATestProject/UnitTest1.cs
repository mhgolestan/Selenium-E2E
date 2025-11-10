using AutoFixture.Xunit2;
using EATestFramework.Driver;
using EATestProject.Model;
using EATestProject.Pages;
using OpenQA.Selenium;

namespace EATestProject;

public class UnitTest1
{
    readonly IWebDriver driver;
    private readonly IHomePage homePage;
    private readonly ICreateProductPage createProductPage;

    public UnitTest1(IHomePage homePage, ICreateProductPage createProductPage)
    {
        this.homePage = homePage;
        this.createProductPage = createProductPage;
    }

    [Theory, AutoData]
    public void Test1(Product product)
    {

        homePage.CreateProduct();
        createProductPage.EnterProductDetails(product);
        homePage.PerformClickOnDetails(product.Name, "Details");
    }

    [Theory, AutoData]
    public void Test2(Product product)
    {

        homePage.CreateProduct();
        createProductPage.EnterProductDetails(product);
    }
}
