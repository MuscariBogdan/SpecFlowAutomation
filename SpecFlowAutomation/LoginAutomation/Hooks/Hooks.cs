using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace LoginAutomation
{
    [Binding]
    public class Hooks
    {
        private IObjectContainer _container;
        private IWebDriver _driver;
        private readonly AppConfig _appConfig;

        public Hooks(IObjectContainer container, AppConfig appConfig)
        {
            _container = container;
            _appConfig = appConfig;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            _driver = new ChromeDriver();
            _container.RegisterInstanceAs(_driver);

            var sharedLoginContext = new SharedLoginContext(_driver, _appConfig);
            _container.RegisterInstanceAs(sharedLoginContext);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_driver != null)
            {
                _driver.Quit();
            }
        }
    }
}
