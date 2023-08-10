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
        }

        public IWebDriver Driver => _driver;
        public LoginPage LoginPage => _loginPage;
        public HomePage HomePage
        {
            get => _homePage;
            set => _homePage = value;
        }
    }
}
