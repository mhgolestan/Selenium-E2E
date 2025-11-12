namespace EATestBDD.Steps;

[Binding]
public class ReusableSteps
{
    private readonly ScenarioContext scenarioContext;
    private readonly IProductRepository productRepository;

    public ReusableSteps(ScenarioContext scenarioContext, IProductRepository productRepository)
    {
        this.scenarioContext = scenarioContext;
        this.productRepository = productRepository;
    }

    [Given(@"I ensure the following product is created")]
    public void GivenIEnsureTheFollowingProductIsCreated(Table table)
    {
        var product = table.CreateInstance<Product>();
        productRepository.AddProduct(product);
        scenarioContext.Set<Product>(product);
    }

    [Then(@"I delete the created ""(.*)"" product for cleanup")]
    public void ThenIDeleteTheCreatedProductForCleanup(string productName)
    {
        productRepository.DeleteProduct(productName);
    }

}
