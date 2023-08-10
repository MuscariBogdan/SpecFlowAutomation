using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using LoginAutomation.PageObjects;

namespace LoginAutomation.Stepdefinitions
{
    [Binding]
    internal class LoginStepDefinitions
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;
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
            homePage = loginPage.PerformLogin("standard_user", "secret_sauce");
        }

        [Then("I should be logged in")]
        public void ThenIShouldBeLoggedIn()
        {
            Assert.True(driver.Url.Contains("inventory"));

            Thread.Sleep(2000);
            driver.Quit();
        }
    }
}
