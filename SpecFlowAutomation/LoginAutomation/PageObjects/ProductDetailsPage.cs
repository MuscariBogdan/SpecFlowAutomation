using OpenQA.Selenium;

namespace LoginAutomation.PageObjects
{
    internal class ProductDetailsPage
    {
        private IWebDriver driver;
        private readonly AppConfig _appConfig;

        public ProductDetailsPage(IWebDriver driver, AppConfig appConfig)
        {
            this.driver = driver;
            _appConfig = appConfig;
        }

        public void AddToCart()
        {
            By addToCartButtonLocator = By.CssSelector("button.btn_inventory");
            IWebElement addToCartButton = driver.FindElement(addToCartButtonLocator);
            addToCartButton.Click();
        }

        public ShoppingCartPage GoToShoppingCart()
        {
            string shoppingCartUrl = _appConfig.GetSetting("ShoppingCartUrl");
            driver.Navigate().GoToUrl(shoppingCartUrl);
            return new ShoppingCartPage(driver, _appConfig);
        }
    }
}
