using TechTalk.SpecFlow;
using System;

namespace EATestBDD.Steps;

[Binding]
public sealed class ProductSteps
{
   
    [Given(@"I click the Product menu")]
    public void GivenIClickTheProductMenu()
    {
        Console.WriteLine("Clicking Product Menu");
        // TODO: Implement navigation logic
    }

    [Given(@"I click the ""(.*)"" link")]
    public void GivenIClickTheLink(string linkName)
    {
        Console.WriteLine($"Clicking {linkName} link");
        // TODO: Implement click logic
    }

    [Given(@"I create product with following details")]
    public void GivenICreateProductWithFollowingDetails(Table table)
    {
        // TODO: Implement product creation logic using data from the table
        Console.WriteLine("Creating a new product");
    }

    [When(@"I click the details link of the newly created product")]
    public void WhenIClickTheDetailsLinkOfTheNewlyCreatedProduct()
    {
        // TODO: Implement logic to find and click the details link
    }

    [Then(@"I see all the product details are created as expected")]
    public void ThenISeeAllTheProductDetailsAreCreatedAsExpected()
    {
        // TODO: Implement verification logic
    }
}
