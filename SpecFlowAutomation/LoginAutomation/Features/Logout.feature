Feature: Logout
    As a user I want to be able to log out from the application
    So that my session is terminated
@logout
Scenario: Successful logout

    Given I am logged in
    When I click the logout button
    Then I should be logged out