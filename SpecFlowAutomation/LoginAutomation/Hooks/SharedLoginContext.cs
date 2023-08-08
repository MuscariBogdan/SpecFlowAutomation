using LoginAutomation.PageObjects;
using OpenQA.Selenium;

namespace LoginAutomation
{
    internal class SharedLoginContext
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private HomePage _homePage;

        public SharedLoginContext(IWebDriver driver)
        {
            _driver = driver;
            _loginPage = new LoginPage(_driver);
            _homePage = _loginPage.PerformLogin("standard_user", "secret_sauce");
        }

        public IWebDriver Driver => _driver;
        public LoginPage LoginPage => _loginPage;
        public HomePage HomePage => _homePage;
    }
}
