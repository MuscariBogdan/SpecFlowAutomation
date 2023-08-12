Feature: Sorting items from A to Z
    As a user
    I want to be able to sort items from A to Z
    So that I can see the items in alphabetical order

    @sorting
    Scenario: Sort items from A to Z
        Given I am logged in
        And I am on the product listing page for sorting
        When I select "Name (A to Z)" from the sort drop-down list
        Then the items should be sorted from A to Z