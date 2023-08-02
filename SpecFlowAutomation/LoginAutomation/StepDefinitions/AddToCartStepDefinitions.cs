using LoginAutomation.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LoginAutomation.StepDefinitions
{
    [Binding]
    public class AddToCartStepDefinitions
    {
        private LoginPage loginPage;
        private ProductListingPage productListingPage;
        private ProductDetailsPage productDetailsPage;
        private ShoppingCartPage shoppingCartPage;
        private string selectedProductName;
        private IWebDriver driver;

        [Given(@"I am logged in for Add to Cart")]
        public void GivenIAmLoggedInForAddToCart()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);

            loginPage.NavigateToLoginPage();
            loginPage.PerformLogin("standard_user", "secret_sauce");
        }

        [Given(@"I am on the product listing page")]
        public void GivenIAmOnTheProductListingPage()
        {
            productListingPage = new ProductListingPage(driver);
        }

        [When("I click on the item with name \"(.*)\"")]
        public void WhenIClickOnTheItemWithName(string itemName)
        {
            selectedProductName = itemName;
            productListingPage.ClickOnProduct(itemName);
        }

        [When("I click the \"Add to Cart\" button")]
        public void WhenIClickTheAddToCartButton()
        {
            productDetailsPage = new ProductDetailsPage(driver);
            productDetailsPage.AddToCart();
        }

        [Then("the item should be added to the cart")]
        public void ThenTheItemShouldBeAddedToTheCart()
        {
            shoppingCartPage = productDetailsPage.GoToShoppingCart();

            bool isItemAdded = shoppingCartPage.IsItemInCart(selectedProductName);
            Assert.IsTrue(isItemAdded, $"The item '{selectedProductName}' should be added to the cart.");

            Thread.Sleep(2000);
            driver.Quit();
        }
    }
}