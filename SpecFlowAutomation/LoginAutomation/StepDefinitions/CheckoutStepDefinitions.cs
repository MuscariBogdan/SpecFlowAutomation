using LoginAutomation.PageObjects;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace LoginAutomation.StepDefinitions
{
    [Binding]
    public class CheckoutStepDefinitions
    {
        private SharedLoginContext _sharedLoginContext;
        private ProductListingPage _productListingPage;
        private ProductDetailsPage _productDetailsPage;
        private ShoppingCartPage _shoppingCartPage;
        private CheckoutPage _checkoutPage;
        private string _selectedProductName;
        private readonly AppConfig _appConfig;

        internal CheckoutStepDefinitions(SharedLoginContext sharedLoginContext, AppConfig appConfig, ShoppingCartPage shoppingCart)
        {
            _sharedLoginContext = sharedLoginContext;
            _appConfig = appConfig;
            _shoppingCartPage = shoppingCart;
        }

        [When(@"I proceed to checkout")]
        public void WhenIProceedToCheckout()
        {
            _checkoutPage = _shoppingCartPage.ProceedToCheckout();
        }

        [When(@"I enter my shipping information")]
        public void WhenIEnterMyShippingInformation()
        {
            _checkoutPage.EnterShippingInformation(
                _appConfig.GetSetting("FirstName"),
                _appConfig.GetSetting("LastName"),
                _appConfig.GetSetting("ZipCode"));
        }

        [When(@"I review my order")]
        public void WhenIReviewMyOrder()
        {
            _checkoutPage.ReviewOrder(_appConfig.GetSetting("FirstItemName"));
        }

        [When(@"I complete the purchase")]
        public void WhenICompleteThePurchase()
        {
            _checkoutPage.CompletePurchase();
        }

        [Then(@"I should see a confirmation of my order")]
        public void ThenIShouldSeeAConfirmationOfMyOrder()
        {
            bool isOrderConfirmed = _checkoutPage.IsOrderConfirmed();
            Assert.IsTrue(isOrderConfirmed, "Order confirmation message should be displayed.");
        }
    }
}
