using NUnit.Framework;

namespace LoginAutomation.StepDefinitions
{
    [Binding]
    internal class LoginStepDefinitions
    {
        private SharedLoginContext _sharedLoginContext;
        private readonly AppConfig _appConfig;

        public LoginStepDefinitions(SharedLoginContext sharedLoginContext, AppConfig appConfig)
        {
            _sharedLoginContext = sharedLoginContext;
            _appConfig = appConfig;
        }

        [Given("I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _sharedLoginContext.LoginPage.NavigateToLoginPage();
        }

        [When(@"I enter my username ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenIEnterMyUsernameAndPassword(string usernameKey, string passwordKey)
        {
            string username = _appConfig.GetSetting(usernameKey);
            string password = _appConfig.GetSetting(passwordKey);

            _sharedLoginContext.HomePage = _sharedLoginContext.LoginPage.PerformLogin(username, password);
        }

        [When("I enter invalid username \"(.*)\" and valid password")]
        public void WhenIEnterInvalidUsernameAndValidPassword(string username)
        {
            string correctPassword = _appConfig.GetSetting("Password");
            _sharedLoginContext.LoginPage.PerformLogin(username, correctPassword);
        }

        [When("I enter valid username and invalid password \"(.*)\"")]
        public void WhenIEnterValidUsernameAndInvalidPassword(string password)
        {
            string correctUser = _appConfig.GetSetting("Username");
            _sharedLoginContext.LoginPage.PerformLogin(correctUser, password);
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

        [When(@"I enter empty username ""([^""]*)"" and empty password ""([^""]*)""")]
        public void WhenIEnterEmptyUsernameAndEmptyPassword(string username, string password)
        {
            _sharedLoginContext.LoginPage.PerformLogin(username, password);
        }

    }
}
