using OpenQA.Selenium;

namespace LoginAutomation.PageObjects
{
    public class ProductDetailsPage
    {
        private IWebDriver driver;

        public ProductDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AddToCart()
        {
            By addToCartButtonLocator = By.CssSelector("button.btn_inventory");
            IWebElement addToCartButton = driver.FindElement(addToCartButtonLocator);
            addToCartButton.Click();
        }

        public ShoppingCartPage GoToShoppingCart()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/cart.html");
            return new ShoppingCartPage(driver);
        }
    }
}
