using OpenQA.Selenium;

namespace LoginAutomation.PageObjects
{
    internal class LoginPage
    {
        private IWebDriver driver;
        private readonly AppConfig _appConfig;

        public LoginPage(IWebDriver driver, AppConfig appConfig)
        {
            this.driver = driver;
            _appConfig = appConfig;
        }

        public void NavigateToLoginPage()
        {
            string baseUrl = _appConfig.GetSetting("BaseUrl");
            driver.Navigate().GoToUrl(baseUrl);
        }

        internal HomePage PerformLogin(string username, string password)
        {
            IWebElement usernameInput = driver.FindElement(By.Id("user-name"));
            IWebElement passwordInput = driver.FindElement(By.Id("password"));

            usernameInput.SendKeys(username);
            passwordInput.SendKeys(password);

            IWebElement loginButton = driver.FindElement(By.Name("login-button"));
            loginButton.Click();


            return new HomePage(driver);
        }

        public bool IsErrorMessageDisplayed()
        {
            try
            {
                IWebElement errorElement = driver.FindElement(By.CssSelector("h3[data-test='error']"));
                return errorElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
