using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LoginAutomation.PageObjects
{
    public class ProductListingPage
    {
        private IWebDriver driver;

        public ProductListingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickOnProduct(string productName)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(2));

            By elementLocator = By.XPath($"//div[contains(@class, 'inventory_item_name') and contains(text(), '{productName}')]");

            wait.Until(driver =>
            {
                try
                {
                    var element = driver.FindElement(elementLocator);
                    return element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    throw new NoSuchElementException($"Element with locator '{elementLocator}' not found.");
                }
                catch (Exception)
                {
                    throw new Exception("Unexpected error occurred while waiting for element.");
                }
            });

            IWebElement productElement = driver.FindElement(elementLocator);
            productElement.Click();
        }
    }

}
