# Login Automation Test Suite

This suite is designed to automate the testing of login, cart management, checkout, and sorting functionality for an e-commerce website. The tests are written using SpecFlow and Selenium WebDriver.

## Table of Contents

- [Getting Started](#getting-started)
- [Features](#features)
- [Page Objects](#page-objects)
- [Step Definitions](#step-definitions)
- [Configurations](#configurations)
- [Running Tests](#running-tests)

## Getting Started

To get started with the test suite, follow these steps:

1. Clone this repository to your local machine.
2. Install the required dependencies, including SpecFlow and Selenium WebDriver.
3. Configure the `appsettings.json` file with your desired settings.
4. Run the tests using the provided test runners.

## Features

The test suite includes the following features:

- **Login:** Automated login scenarios for successful and unsuccessful login attempts.

- **Add to Cart:** Scenarios for adding items to the shopping cart.

- **Checkout:** Automated checkout process, including entering shipping information, reviewing the order, and completing the purchase.

- **Logout:** Testing the logout functionality.

- **Remove Items from Cart:** Testing the removal of items from the shopping cart.

- **Sorting Items:** Sorting items from A to Z on the product listing page.

## Page Objects

The test suite follows the Page Object Model design pattern, separating page actions from step definitions. Key page objects include:

- `LoginPage`: Represents the login page and provides methods for login actions.
- `ProductListingPage`: Represents the product listing page and provides methods for interacting with products and sorting options.
- `ProductDetailsPage`: Represents the product details page and provides methods for adding items to the cart.
- `ShoppingCartPage`: Represents the shopping cart page and provides methods for managing cart items and proceeding to checkout.
- `CheckoutPage`: Represents the checkout page and provides methods for completing the checkout process.

## Step Definitions

Step definitions are organized by feature and include:

- **LoginStepDefinitions:** Steps for testing the login functionality.
- **AddToCartStepDefinitions:** Steps for adding items to the shopping cart.
- **CheckoutStepDefinitions:** Steps for testing the checkout process.
- **LogoutStepDefinitions:** Steps for testing the logout functionality.
- **RemoveItemsFromCartStepDefinitions:** Steps for removing items from the shopping cart.
- **SortingItemsFromAToZStepDefinitions:** Steps for sorting items on the product listing page.

## Configurations

- `AppConfig`: Configuration class to read settings from `appsettings.json`, including base URL, credentials, and other configuration options.

## Running Tests

To run the tests, use the provided test runners:

- Execute the test suite using SpecFlow.
- Optionally, configure and customize the test execution environment (e.g., browsers, parallel execution).

Happy testing!
