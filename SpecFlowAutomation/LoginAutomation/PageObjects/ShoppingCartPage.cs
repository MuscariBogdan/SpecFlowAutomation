using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace LoginAutomation.PageObjects
{
    internal class ShoppingCartPage
    {
        private IWebDriver driver;
        private readonly AppConfig _appConfig;

        public ShoppingCartPage(IWebDriver driver, AppConfig appConfig)
        {
            this.driver = driver;
            _appConfig = appConfig;
        }

        public bool IsItemInCart(string itemName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            By itemLocator = By.XPath($"//*[contains(text(), '{itemName}')]");


            bool isItemPresent = wait.Until(ExpectedConditions.ElementExists(itemLocator)) != null;

            return isItemPresent;
        }

        internal void RemoveItemFromCart(string selectedProductName)
        {
            throw new NotImplementedException();
        }
    }
}
