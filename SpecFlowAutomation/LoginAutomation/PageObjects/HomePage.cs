using OpenQA.Selenium;

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

            Thread.Sleep(1500);
        }

        /*public ProductListingPage GoToProductListingPage()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/inventory.html");

            return new ProductListingPage(driver);
        }*/
    }
}
