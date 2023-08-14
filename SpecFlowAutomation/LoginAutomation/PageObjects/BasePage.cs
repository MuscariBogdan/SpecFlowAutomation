using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LoginAutomation.PageObjects
{
    internal abstract class BasePage
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;
        protected AppConfig _appConfig;

        public BasePage(IWebDriver driver, AppConfig appConfig)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _appConfig = appConfig;
        }

        protected IWebElement FindElement(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected void ClickElement(By locator)
        {
            FindElement(locator).Click();
        }

        protected SelectElement SelectDropdownOption(By locator)
        {
            return new SelectElement(FindElement(locator));
        }

        protected SelectElement SelectDropdownOption(By locator, string optionText)
        {
            SelectElement selectElement = SelectDropdownOption(locator);
            selectElement.SelectByText(optionText);
            return selectElement;
        }
    }
}
