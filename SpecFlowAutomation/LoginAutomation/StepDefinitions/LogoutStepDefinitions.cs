using LoginAutomation.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace LoginAutomation.StepDefinitions
{
    [Binding]
    public class LogoutStepDefinitions
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;

        [Given("I am logged in for Logout")]
        public void GivenIAmLoggedInForLogout()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            loginPage.NavigateToLoginPage();
            homePage = loginPage.PerformLogin("standard_user", "secret_sauce");
        }

        [When("I click the logout button")]
        public void WhenIClickTheLogoutButton()
        {
            homePage.ClickLogoutButton();
        }

        [Then("I should be logged out")]
        public void ThenIShouldBeLoggedOut()
        {
            var loginButton = driver.FindElements(By.CssSelector("input.submit-button.btn_action[data-test='login-button']"));
            Assert.IsTrue(loginButton.Count > 0, "User is not logged out. Login button is not displayed.");

            driver.Quit();
        }
    }
}
