using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            IWebElement logoutButton = driver.FindElement(By.Id("logout-button"));
            logoutButton.Click();
        }

        public ProductListingPage GoToProductListingPage()
        {
            driver.Navigate().GoToUrl("https://www.example.com/product-listing");

            return new ProductListingPage(driver);
        }

    }
}
