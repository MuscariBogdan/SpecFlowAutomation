using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LoginAutomation
{
    internal class CheckoutPage
    {
        private IWebDriver _driver;
        private readonly AppConfig _appConfig;

        public CheckoutPage(IWebDriver driver, AppConfig appConfig)
        {
            _driver = driver;
            _appConfig = appConfig;
        }

        public void EnterShippingInformation(string firstName, string lastName, string zipCode)
        {
            // Locate input fields and enter shipping information
            IWebElement firstNameInput = _driver.FindElement(By.Id("first-name"));
            IWebElement lastNameInput = _driver.FindElement(By.Id("last-name"));
            IWebElement zipCodeInput = _driver.FindElement(By.Id("postal-code"));

            firstNameInput.SendKeys(firstName);
            lastNameInput.SendKeys(lastName);
            zipCodeInput.SendKeys(zipCode);

            // Click on next/continue button
            IWebElement continueButton = _driver.FindElement(By.XPath("//input[@value='Continue']"));
            continueButton.Click();
        }

        public bool ReviewOrder(string productName)
        {
            By itemLocator = By.XPath($"//div[@class='inventory_item_name' and text()='{productName}']");

            var isSummaryDisplayed = _driver.FindElement(By.Id("checkout_summary_container")).Displayed;
            var isItemPresent = _driver.FindElements(itemLocator).Count > 0;

            return isSummaryDisplayed && isItemPresent;
        }

        public void CompletePurchase()
        {
            IWebElement finishButton = _driver.FindElement(By.Id("finish"));
            finishButton.Click();
        }

        public bool IsOrderConfirmed()
        {
            // Check if order confirmation message is displayed
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            By confirmationMessageLocator = By.XPath("//div[contains(text(), 'Your order is complete')]");

            return wait.Until(ExpectedConditions.ElementIsVisible(confirmationMessageLocator)) != null;
        }
    }
}
