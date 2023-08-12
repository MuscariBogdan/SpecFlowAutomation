using LoginAutomation.PageObjects;
using OpenQA.Selenium;

namespace LoginAutomation
{
    internal class SharedLoginContext
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private HomePage _homePage;
        private readonly AppConfig _appConfig;

        public SharedLoginContext(IWebDriver driver, AppConfig appConfig)
        {
            _driver = driver;

            _appConfig = appConfig;
            _loginPage = new LoginPage(_driver, _appConfig);
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
