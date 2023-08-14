using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LoginAutomation.PageObjects
{
    internal class ProductListingPage : BasePage
    {
        public ProductListingPage(IWebDriver driver, AppConfig appConfig)
            : base(driver, appConfig)
        {
        }

        public void ClickOnProduct(string productName)
        {
            By elementLocator = By.XPath($"//div[contains(@class, 'inventory_item_name') and contains(text(), '{productName}')]");
            ClickElement(elementLocator);
        }

        public void SelectSortingOption(string sortingOption)
        {
            By sortDropdownLocator = By.ClassName("product_sort_container");
            SelectDropdownOption(sortDropdownLocator, sortingOption);
        }

        public bool AreItemsSorted(string sortingOrder)
        {
            IReadOnlyCollection<IWebElement> items = _driver.FindElements(By.ClassName("inventory_item_name"));
            List<string> itemNames = items.Select(item => item.Text).ToList();


            for (int i = 0; i < itemNames.Count - 1; i++)
            {
                int comparisonResult;
                if (sortingOrder == "AtoZ")
                {
                    comparisonResult = string.Compare(itemNames[i + 1], itemNames[i], StringComparison.Ordinal);
                }
                else if (sortingOrder == "ZtoA")
                {
                    comparisonResult = string.Compare(itemNames[i], itemNames[i + 1], StringComparison.Ordinal);
                }
                else
                {
                    throw new ArgumentException("Invalid sorting order specified. Use 'AtoZ' or 'ZtoA'.", nameof(sortingOrder));
                }

                if (comparisonResult < 0)
                {
                    return false; // The items are not sorted as expected
                }
            }

            return true;
        }
    }

}
