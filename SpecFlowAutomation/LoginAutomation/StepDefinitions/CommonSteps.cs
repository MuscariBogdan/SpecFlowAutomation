using LoginAutomation.PageObjects;
using NUnit.Framework;
namespace LoginAutomation.StepDefinitions
{
    [Binding]
    public class CommonSteps
    {
        private SharedLoginContext _sharedLoginContext;

        internal CommonSteps(SharedLoginContext sharedLoginContext)
        {
            _sharedLoginContext = sharedLoginContext;
        }

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            _sharedLoginContext.LoginPage.NavigateToLoginPage();
            _sharedLoginContext.HomePage = _sharedLoginContext.LoginPage.PerformLogin("standard_user", "secret_sauce");
        }
    }
}
