using LoginAutomation.PageObjects;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace LoginAutomation.StepDefinitions
{
    [Binding]
    public class RemoveItemsFromCartStepDefinitions
    {
        private SharedLoginContext _sharedLoginContext;
        private ShoppingCartPage _shoppingCartPage;
        private ProductListingPage _productListingPage;
        private ProductDetailsPage _productDetailsPage;
        private string _selectedProductName;
        private readonly AppConfig _appConfig;

        internal RemoveItemsFromCartStepDefinitions(SharedLoginContext sharedLoginContext, AppConfig appConfig)
        {
            _sharedLoginContext = sharedLoginContext;
            _appConfig = appConfig;
        }

        [Given(@"I have added items to my shopping cart")]
        public void GivenIHaveAddedItemsToMyShoppingCart()
        {
            _selectedProductName = _appConfig.GetSetting("FirstItemName");

            _productDetailsPage = new ProductDetailsPage(_sharedLoginContext.Driver, _appConfig);
            _productDetailsPage.AddItemsToShoppingCart(_selectedProductName);
        }

        [When(@"I remove an item from the cart")]
        public void WhenIRemoveAnItemFromTheCart()
        {
            _shoppingCartPage = new ShoppingCartPage(_sharedLoginContext.Driver, _appConfig);
            _shoppingCartPage.RemoveItemFromCart(_selectedProductName);
            _shoppingCartPage = _productDetailsPage.GoToShoppingCart();
        }

        [Then(@"the item should be removed from the cart")]
        public void ThenTheItemShouldBeRemovedFromTheCart()
        {
            bool isItemRemoved = !_shoppingCartPage.IsItemInCart(_selectedProductName);
            Assert.IsTrue(isItemRemoved, $"The item '{_selectedProductName}' should be removed from the cart.");
        }
    }
}
