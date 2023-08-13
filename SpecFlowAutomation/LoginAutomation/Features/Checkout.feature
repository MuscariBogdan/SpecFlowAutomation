Feature: Checkout
    As a user I want to be able to complete the checkout process
    So that I can finalize my purchase

@checkout
Scenario: Complete the checkout process
    Given I am logged in
    And I have added items to my shopping cart
    When I proceed to checkout
    And I enter my shipping information
    And I review my order
    And I complete the purchase
    Then I should see a confirmation of my order
