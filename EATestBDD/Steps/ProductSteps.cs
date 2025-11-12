using ProductAPI.Repository;

namespace EATestBDD.Steps;

[Binding]
public sealed class ProductSteps
{
    private readonly ScenarioContext scenarioContext;
    private readonly IHomePage homePage;
    private readonly IProductPage productPage;
    private readonly IProductRepository productRepository;

    public ProductSteps(ScenarioContext scenarioContext,
                        IHomePage homePage,
                        IProductPage productPage,
                        IProductRepository productRepository)
    {
        this.scenarioContext = scenarioContext;
        this.homePage = homePage;
        this.productPage = productPage;
        this.productRepository = productRepository;
    }

    [Given(@"I click the Product menu")]
    public void GivenIClickTheProductMenu()
    {
        // var getProduct = productRepository.GetAllProducts();
        // productRepository.DeleteProduct(3);
        homePage.ClickProduct();
    }

    [Given(@"I click the ""(.*)"" link")]
    public void GivenIClickTheLink(string create)
    {
        homePage.ClickCreate();
    }
    
    [Given(@"I create product with following details")]
    public void GivenICreateProductWithFollowingDetails(Table table)
    {
        var product = table.CreateInstance<Product>();
        productPage.EnterProductDetails(product);
        scenarioContext.Set<Product>(product);
    }

    [When(@"I click the details link of the newly created product")]
    public void WhenIClickTheDetailsLinkOfTheNewlyCreatedProduct()
    {
        var product = scenarioContext.Get<Product>();
        homePage.PerformClickOnSpecialValue(product.Name, "Details");
    }

    [Then(@"I see all the product details are created as expected")]
    public void ThenISeeAllTheProductDetailsAreCreatedAsExpected()
    {
        var product = scenarioContext.Get<Product>();
        var actualProduct = productPage.GetProductDetails();
        actualProduct.Should().BeEquivalentTo(product, option => option.Excluding(x => x.Id));
    }
}
