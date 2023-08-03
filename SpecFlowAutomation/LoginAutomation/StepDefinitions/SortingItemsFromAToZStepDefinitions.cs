using LoginAutomation.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace LoginAutomation.StepDefinitions
{
    [Binding]
    public class SortingItemsFromAToZStepDefinitions
    {
        private HomePage homePage;
        private LoginPage loginPage;
        private ProductListingPage productListingPage;
        private IWebDriver driver;

        [Given(@"I am logged in for sorting")]
        public void GivenIAmLoggedInForSorting()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);

            loginPage.NavigateToLoginPage();
            loginPage.PerformLogin("standard_user", "secret_sauce");
        }

        [Given(@"I am on the product listing page for sorting")]
        public void GivenIAmOnTheProductListingPageForSorting()
        {
            productListingPage = new ProductListingPage(driver);
        }

        [When(@"I select ""(.*)"" from the sort drop-down list")]
        public void WhenISelectFromTheSortDropDownList(string sortingOption)
        {
            productListingPage.SelectSortingOption(sortingOption);
        }

        [Then(@"the items should be sorted from A to Z")]
        public void ThenTheItemsShouldBeSortedFromAToZ()
        {
            var sortingOrder = "AtoZ";

            bool isSorted = productListingPage.AreItemsSorted(sortingOrder);
            Assert.IsTrue(isSorted, "The items should be sorted from A to Z.");

            driver.Quit();
        }
    }
}
