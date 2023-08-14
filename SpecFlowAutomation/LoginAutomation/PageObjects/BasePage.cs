using OpenQA.Selenium;

namespace LoginAutomation.PageObjects
{
    internal abstract class BasePage
    {
        protected IWebDriver _driver;
        protected AppConfig _appConfig;

        public BasePage(IWebDriver driver, AppConfig appConfig)
        {
            _driver = driver;
            _appConfig = appConfig;
        }
    }
}
