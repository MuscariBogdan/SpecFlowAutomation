using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using LoginAutomation.PageObjects;

namespace LoginAutomation.Stepdefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        [Given("I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            loginPage.NavigateToLoginPage();
        }

        [When("I enter my username and password")]
        public void WhenIEnterMyUsernameAndPassword()
        {
            loginPage.Login("standard_user", "secret_sauce");
        }

        [When("I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            loginPage.ClickLoginButton();
        }

        [Then("I should be logged in")]
        public void ThenIShouldBeLoggedIn()
        {
            Assert.True(driver.Url.Contains("inventory"));

            driver.Quit();
        }
    }
}
