using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace LoginAutomation.PageObjects
{
    internal class ShoppingCartPage
    {
        private IWebDriver driver;

        public ShoppingCartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool IsItemInCart(string itemName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            By itemLocator = By.XPath($"//*[contains(text(), '{itemName}')]");


            bool isItemPresent = wait.Until(ExpectedConditions.ElementExists(itemLocator)) != null;

            return isItemPresent;
        }
    }
}
