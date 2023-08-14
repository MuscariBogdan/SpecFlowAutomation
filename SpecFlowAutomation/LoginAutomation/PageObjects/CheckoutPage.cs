using LoginAutomation.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LoginAutomation
{
    internal class CheckoutPage : BasePage
    {
        public CheckoutPage(IWebDriver driver, AppConfig appConfig)
            : base(driver, appConfig)
        {
        }

        public void EnterShippingInformation(string firstName, string lastName, string postalCode)
        {
            var dataEntries = new List<(string, string)>()
            {
                ("first-name", firstName),
                ("last-name", lastName),
                ("postal-code", postalCode)
            };

            foreach (var (elementID, value) in dataEntries)
            {
                IWebElement inputElement = FindElement(By.Id(elementID));
                inputElement.SendKeys(value);
            }    

            IWebElement continueButton = FindElement(By.XPath("//input[@value='Continue']"));
            continueButton.Click();
        }

        public bool ReviewOrder(string productName)
        {
            By itemLocator = By.XPath($"//div[@class='inventory_item_name' and text()='{productName}']");

            var isSummaryDisplayed = FindElement(By.Id("checkout_summary_container")).Displayed;
            var isItemPresent = _driver.FindElements(itemLocator).Count > 0;

            return isSummaryDisplayed && isItemPresent;
        }

        public void CompletePurchase()
        {
            IWebElement finishButton = FindElement(By.Id("finish"));
            finishButton.Click();
        }

        public bool IsOrderConfirmed()
        {
            // Check if order confirmation message is displayed
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            By confirmationMessageLocator = By.XPath("//h2[text()='Thank you for your order!']\r\n");

            return wait.Until(ExpectedConditions.ElementIsVisible(confirmationMessageLocator)) != null;
        }
    }
}
