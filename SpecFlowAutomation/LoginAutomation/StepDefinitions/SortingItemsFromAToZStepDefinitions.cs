using LoginAutomation.PageObjects;
using NUnit.Framework;

namespace LoginAutomation.StepDefinitions
{
    [Binding]
    public class SortingItemsFromAToZStepDefinitions
    {
        private SharedLoginContext _sharedLoginContext;
        private ProductListingPage _productListingPage;
        private AppConfig _appConfig;

        internal SortingItemsFromAToZStepDefinitions(SharedLoginContext sharedLoginContext)
        {
            _sharedLoginContext = sharedLoginContext;
        }

        [Given(@"I am on the product listing page for sorting")]
        public void GivenIAmOnTheProductListingPageForSorting()
        {
            _productListingPage = new ProductListingPage(_sharedLoginContext.Driver, _appConfig);
        }

        [When(@"I select ""(.*)"" from the sort drop-down list")]
        public void WhenISelectFromTheSortDropDownList(string sortingOption)
        {
            _productListingPage.SelectSortingOption(sortingOption);
        }

        [Then(@"the items should be sorted from A to Z")]
        public void ThenTheItemsShouldBeSortedFromAToZ()
        {
            var sortingOrder = "AtoZ";

            bool isSorted = _productListingPage.AreItemsSorted(sortingOrder);
            Assert.IsTrue(isSorted, "The items should be sorted from A to Z.");
        }
    }
}
