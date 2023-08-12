namespace LoginAutomation.StepDefinitions
{
    [Binding]
    public class CommonSteps
    {
        private SharedLoginContext _sharedLoginContext;
        private readonly AppConfig _appConfig;

        internal CommonSteps(SharedLoginContext sharedLoginContext, AppConfig appConfig)
        {
            _sharedLoginContext = sharedLoginContext;
            _appConfig = appConfig;
        }

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {

            _sharedLoginContext.LoginPage.NavigateToLoginPage();
            _sharedLoginContext.HomePage = _sharedLoginContext.LoginPage.PerformLogin(
                _appConfig.GetSetting("Username"), _appConfig.GetSetting("Password"));
        }
    }
}
