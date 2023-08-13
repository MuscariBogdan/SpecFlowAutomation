using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace LoginAutomation.PageObjects
{
    internal class ShoppingCartPage
    {
        private IWebDriver _driver;
        private readonly AppConfig _appConfig;

        public ShoppingCartPage(IWebDriver driver, AppConfig appConfig)
        {
            _driver = driver;
            _appConfig = appConfig;
        }

        public bool IsItemInCart(string itemName)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));

            By itemLocator = By.XPath($"//*[contains(text(), '{itemName}')]");


            /*bool isItemPresent = wait.Until(ExpectedConditions.ElementExists(itemLocator)) != null;

            return isItemPresent;*/

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
    }
}
