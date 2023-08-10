using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using LoginAutomation.PageObjects;
using TechTalk.SpecFlow;

namespace LoginAutomation.StepDefinitions
{
    [Binding]
    internal class LoginStepDefinitions
    {
        private SharedLoginContext _sharedLoginContext;

        public LoginStepDefinitions(SharedLoginContext sharedLoginContext)
        {
            _sharedLoginContext = sharedLoginContext;
        }

        [Given("I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _sharedLoginContext.LoginPage.NavigateToLoginPage();
        }

        [When(@"I enter my username ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenIEnterMyUsernameAndPassword(string username, string password)
        {
            _sharedLoginContext.HomePage = _sharedLoginContext.LoginPage.PerformLogin(username, password);
        }

        [When("I enter invalid username \"(.*)\" and valid password")]
        public void WhenIEnterInvalidUsernameAndValidPassword(string username)
        {
            _sharedLoginContext.LoginPage.PerformLogin(username, "secret_sauce");
        }

        [When("I enter valid username and invalid password \"(.*)\"")]
        public void WhenIEnterValidUsernameAndInvalidPassword(string password)
        {
            _sharedLoginContext.LoginPage.PerformLogin("standard_user", password);
        }

        [When(@"I enter invalid username ""([^""]*)"" and invalid password ""([^""]*)""")]
        public void WhenIEnterInvalidUsernameAndInvalidPassword(string username, string password)
        {
            _sharedLoginContext.LoginPage.PerformLogin(username, password);
        }

        [Then("I should be logged in")]
        public void ThenIShouldBeLoggedIn()
        {
            Assert.True(_sharedLoginContext.Driver.Url.Contains("inventory"));
        }

        [Then("I should see an error message for invalid login")]
        public void ThenIShouldSeeAnErrorMessageForInvalidLogin()
        {
            Assert.IsTrue(_sharedLoginContext.LoginPage.IsErrorMessageDisplayed());
        }
    }
}
