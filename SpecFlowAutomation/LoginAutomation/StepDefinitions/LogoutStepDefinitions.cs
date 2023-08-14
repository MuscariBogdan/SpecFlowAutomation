using LoginAutomation.PageObjects;
using OpenQA.Selenium;
using NUnit.Framework;

namespace LoginAutomation.StepDefinitions
{
    [Binding]
    public class LogoutStepDefinitions
    {
        private SharedLoginContext _sharedLoginContext;
        private HomePage _homePage;

        internal LogoutStepDefinitions(SharedLoginContext sharedLoginContext)
        {
            _sharedLoginContext = sharedLoginContext;
        }

        [When("I click the logout button")]
        public void WhenIClickTheLogoutButton()
        {
            _homePage = _sharedLoginContext.HomePage;
            _homePage.ClickLogoutButton();
        }

        [Then("I should be logged out")]
        public void ThenIShouldBeLoggedOut()
        {
            var loginButton = _sharedLoginContext.Driver.FindElements(By.CssSelector("input.submit-button.btn_action[data-test='login-button']"));
            Assert.IsTrue(loginButton.Count > 0, "User is not logged out. Login button is not displayed.");
        }
    }
}
