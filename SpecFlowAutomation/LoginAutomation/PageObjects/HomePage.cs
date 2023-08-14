using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LoginAutomation.PageObjects
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver driver, AppConfig appConfig)
            : base(driver, appConfig)
        {
        }

        public void ClickLogoutButton()
        {
            ClickBurgerMenu();

            IWebElement logoutButton = _driver.FindElement(By.XPath("//a[@id='logout_sidebar_link']"));
            logoutButton.Click();
        }

        public void ClickBurgerMenu()
        {
            IWebElement burgerMenu = _driver.FindElement(By.XPath("//button[@id='react-burger-menu-btn']"));
            burgerMenu.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@id='logout_sidebar_link']")));
        }
    }
}
