using OpenQA.Selenium;

namespace LoginAutomation.PageObjects
{
    internal class ProductDetailsPage
    {
        private IWebDriver _driver;
        private readonly AppConfig _appConfig;

        public ProductDetailsPage(IWebDriver driver, AppConfig appConfig)
        {
            _driver = driver;
            _appConfig = appConfig;
        }

        public void AddToCart()
        {
            By addToCartButtonLocator = By.CssSelector("button.btn_inventory");
            IWebElement addToCartButton = _driver.FindElement(addToCartButtonLocator);
            addToCartButton.Click();
        }

        public ShoppingCartPage GoToShoppingCart()
        {
            string shoppingCartUrl = _appConfig.GetSetting("CartUrl");
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/cart.html");
            return new ShoppingCartPage(_driver, _appConfig);
        }

        public void AddItemsToShoppingCart(string itemToBeAdded)
        {

            var productListingPage = new ProductListingPage(_driver);
            productListingPage.ClickOnProduct(itemToBeAdded);

            AddToCart();
        }
    }
}
