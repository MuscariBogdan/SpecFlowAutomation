using OpenQA.Selenium;

namespace LoginAutomation.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToLoginPage()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com");
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
    }
}
