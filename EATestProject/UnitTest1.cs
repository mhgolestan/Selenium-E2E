using AutoFixture.Xunit2;
using EATestProject.Model;
using EATestProject.Pages;
using FluentAssertions;
using OpenQA.Selenium;

namespace EATestProject;

public class UnitTest1
{
    readonly IWebDriver driver;
    private readonly IHomePage homePage;
    private readonly IProductPage productPage;

    public UnitTest1(IHomePage homePage, IProductPage productPage)
    {
        this.homePage = homePage;
        this.productPage = productPage;
    }

    [Theory, AutoData]
    public void Test1(Product product)
    {

        homePage.CreateProduct();
        productPage.EnterProductDetails(product);
        homePage.PerformClickOnDetails(product.Name, "Details");
        var actualProduct = productPage.GetProductDetails();
        actualProduct.ShouldBeEquivalentTo(product, option => option.Excluding(x => x.Id));
    }

    [Theory, AutoData]
    public void Test2(Product product)
    {

        homePage.CreateProduct();
        productPage.EnterProductDetails(product);
    }
}
