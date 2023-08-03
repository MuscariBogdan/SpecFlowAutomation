using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LoginAutomation.PageObjects
{
    public class ProductListingPage
    {
        private IWebDriver driver;

        public ProductListingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickOnProduct(string productName)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(2));

            By elementLocator = By.XPath($"//div[contains(@class, 'inventory_item_name') and contains(text(), '{productName}')]");

            wait.Until(driver =>
            {
                try
                {
                    var element = driver.FindElement(elementLocator);
                    return element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    throw new NoSuchElementException($"Element with locator '{elementLocator}' not found.");
                }
                catch (Exception)
                {
                    throw new Exception("Unexpected error occurred while waiting for element.");
                }
            });

            IWebElement productElement = driver.FindElement(elementLocator);
            productElement.Click();
        }

        public void SelectSortingOption(string sortingOption)
        {
            IWebElement sortDropdown = driver.FindElement(By.ClassName("product_sort_container"));
            var selectElement = new SelectElement(sortDropdown);
            selectElement.SelectByText(sortingOption);


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("inventory_list")));
        }

        public bool AreItemsSorted(string sortingOrder)
        {
            IReadOnlyCollection<IWebElement> items = driver.FindElements(By.ClassName("inventory_item_name"));
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
