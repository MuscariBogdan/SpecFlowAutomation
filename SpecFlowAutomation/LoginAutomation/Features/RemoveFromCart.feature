Feature: Remove Items from Cart
    As a user I want to be able to remove items from my shopping cart
    So that I can manage my cart contents

    @removefromcart
    Scenario: Remove an item from the cart
        Given I am logged in
        And I have added items to my shopping cart
        When I remove an item from the cart
        Then the item should be removed from the cart
