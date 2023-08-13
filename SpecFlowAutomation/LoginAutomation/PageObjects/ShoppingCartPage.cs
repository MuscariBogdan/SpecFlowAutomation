using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace LoginAutomation.PageObjects
{
    internal class ShoppingCartPage
    {
        private IWebDriver _driver;
        private readonly AppConfig _appConfig;
        private ProductDetailsPage _productDetailsPage;
        private ShoppingCartPage _shoppingCartPage;

        public ShoppingCartPage(IWebDriver driver, AppConfig appConfig)
        {
            _driver = driver;
            _appConfig = appConfig;
        }

        public bool IsItemInCart(string itemName)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));

            By itemLocator = By.XPath($"//*[contains(text(), '{itemName}')]");

            try
            {
                wait.Until(ExpectedConditions.ElementExists(itemLocator));
                return true; // Element was found, item is in the cart
            }
            catch (WebDriverTimeoutException)
            {
                return false; // Element was not found, item is not in the cart
            }
        }

        internal void RemoveItemFromCart(string selectedProductName)
        {
            string buttonName = $"remove-{selectedProductName.ToLower().Replace(" ", "-")}";
            IWebElement removeButton = _driver.FindElement(By.Id(buttonName));

            removeButton.Click();
        }

        public CheckoutPage ProceedToCheckout()
        {
            _shoppingCartPage = _productDetailsPage.GoToShoppingCart();
            // Click on the "CHECKOUT" button to proceed to checkout
            IWebElement checkoutButton = _driver.FindElement(By.Id("checkout"));
            checkoutButton.Click();

            // Return a new instance of CheckoutPage
            return new CheckoutPage(_driver, _appConfig);
        }
    }
}
