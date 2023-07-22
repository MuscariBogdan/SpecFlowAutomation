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

        public void Login(string username, string password)
        {
            var usernameInput = driver.FindElement(By.Id("user-name"));
            var passwordInput = driver.FindElement(By.Id("password"));

            usernameInput.SendKeys(username);
            passwordInput.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            var loginButton = driver.FindElement(By.Name("login-button"));
            loginButton.Click();
        }
    }
}
