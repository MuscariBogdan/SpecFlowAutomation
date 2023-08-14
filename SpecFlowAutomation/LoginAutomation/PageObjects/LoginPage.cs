using OpenQA.Selenium;

namespace LoginAutomation.PageObjects
{
    internal class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver, AppConfig appConfig)
            : base(driver, appConfig)
        {
        }

        public void NavigateToLoginPage()
        {
            string baseUrl = _appConfig.GetSetting("BaseUrl");
            _driver.Navigate().GoToUrl(baseUrl);
        }

        internal HomePage PerformLogin(string username, string password)
        {
            IWebElement usernameInput = _driver.FindElement(By.Id("user-name"));
            IWebElement passwordInput = _driver.FindElement(By.Id("password"));

            usernameInput.SendKeys(username);
            passwordInput.SendKeys(password);

            IWebElement loginButton = _driver.FindElement(By.Name("login-button"));
            loginButton.Click();


            return new HomePage(_driver, _appConfig);
        }

        public bool IsErrorMessageDisplayed()
        {
            try
            {
                IWebElement errorElement = _driver.FindElement(By.CssSelector("h3[data-test='error']"));
                return errorElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
