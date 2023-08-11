using LoginAutomation.PageObjects;
using NUnit.Framework;

namespace LoginAutomation.StepDefinitions
{
    [Binding]
    public class AddToCartStepDefinitions
    {
        private SharedLoginContext _sharedLoginContext;
        private ProductListingPage _productListingPage;
        private ProductDetailsPage _productDetailsPage;
        private ShoppingCartPage _shoppingCartPage;
        private string _selectedProductName;

        internal AddToCartStepDefinitions(SharedLoginContext sharedLoginContext)
        {
            _sharedLoginContext = sharedLoginContext;
        }

        [Given(@"I am on the product listing page")]
        public void GivenIAmOnTheProductListingPage()
        {
            _productListingPage = new ProductListingPage(_sharedLoginContext.Driver);
        }

        [When("I click on the item with name \"(.*)\"")]
        public void WhenIClickOnTheItemWithName(string itemName)
        {
            _selectedProductName = itemName;
            _productListingPage.ClickOnProduct(itemName);
        }

        [When("I click the \"Add to Cart\" button")]
        public void WhenIClickTheAddToCartButton()
        {
            _productDetailsPage = new ProductDetailsPage(_sharedLoginContext.Driver);
            _productDetailsPage.AddToCart();
        }

        [Then("the item should be added to the cart")]
        public void ThenTheItemShouldBeAddedToTheCart()
        {
            _shoppingCartPage = _productDetailsPage.GoToShoppingCart();

            bool isItemAdded = _shoppingCartPage.IsItemInCart(_selectedProductName);
            Assert.IsTrue(isItemAdded, $"The item '{_selectedProductName}' should be added to the cart.");
        }
    }
}
