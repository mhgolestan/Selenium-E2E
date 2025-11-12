using ProductAPI.Repository;

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

    [Then(@"I delete the created ""(.*)"" product for cleanup")]
    public void ThenIDeleteTheCreatedProductForCleanup(string productName)
    {
        productRepository.DeleteProduct(productName);
    }

}
