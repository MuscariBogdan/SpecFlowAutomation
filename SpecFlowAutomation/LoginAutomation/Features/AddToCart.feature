Feature: Add item to shopping cart
	As a user I want to be able to add an item to my shopping cart
	So that I can proceed with the purchase
@addtocart
Scenario: Add an item to the cart
Given I am logged in
And I am on the product listing page
When I click on the item with name "Sauce Labs Backpack"
And I click the "Add to Cart" button
Then the item should be added to the cart
