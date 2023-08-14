using OpenQA.Selenium;

namespace LoginAutomation.PageObjects
{
    internal class ProductDetailsPage : BasePage
    {
        public ProductDetailsPage(IWebDriver driver, AppConfig appConfig)
            : base(driver, appConfig) { }

        public void AddToCart()
        {
            By addToCartButtonLocator = By.CssSelector("button.btn_inventory");
            IWebElement addToCartButton = FindElement(addToCartButtonLocator);
            addToCartButton.Click();
        }

        public ShoppingCartPage GoToShoppingCart()
        {
            By shoppingCartButtonLocator = By.CssSelector("div.shopping_cart_container > a.shopping_cart_link");
            IWebElement shoppingCartButton = FindElement(shoppingCartButtonLocator);
            shoppingCartButton.Click();

            return new ShoppingCartPage(_driver, _appConfig);
        }

        public void AddItemsToShoppingCart(string itemToBeAdded)
        {

            var productListingPage = new ProductListingPage(_driver, _appConfig);
            productListingPage.ClickOnProduct(itemToBeAdded);

            AddToCart();
        }
    }
}
