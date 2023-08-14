using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace LoginAutomation.PageObjects
{
    internal class ShoppingCartPage :BasePage
    {
        private ProductDetailsPage _productDetailsPage;

        public ShoppingCartPage(IWebDriver driver, AppConfig appConfig)
            : base(driver, appConfig)
        {
            _productDetailsPage = new ProductDetailsPage(driver, appConfig);
        }

        public bool IsItemInCart(string itemName)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));

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
            IWebElement removeButton = FindElement(By.Id(buttonName));

            removeButton.Click();
        }

        public CheckoutPage ProceedToCheckout()
        {
            _productDetailsPage.GoToShoppingCart();

            IWebElement checkoutButton = FindElement(By.Id("checkout"));
            checkoutButton.Click();

            return new CheckoutPage(_driver, _appConfig);
        }
    }
}
