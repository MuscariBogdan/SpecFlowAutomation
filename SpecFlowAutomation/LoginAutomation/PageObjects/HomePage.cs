using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LoginAutomation.PageObjects
{
    internal class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickLogoutButton()
        {
            ClickBurgerMenu();

            IWebElement logoutButton = driver.FindElement(By.XPath("//a[@id='logout_sidebar_link']"));
            logoutButton.Click();
        }

        public void ClickBurgerMenu()
        {
            IWebElement burgerMenu = driver.FindElement(By.XPath("//button[@id='react-burger-menu-btn']"));
            burgerMenu.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@id='logout_sidebar_link']")));
        }
    }
}
