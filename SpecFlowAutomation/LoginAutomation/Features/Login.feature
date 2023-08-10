Feature: Login

@login
Scenario: Successful login

Given I am on the login page
When I enter my username "standard_user" and password "secret_sauce"
Then I should be logged in

@login
  Scenario: Unsuccessful login attempts
    Given I am on the login page
    When I enter invalid username "invalid_user" and valid password
    Then I should see an error message for invalid login

    Given I am on the login page
    When I enter valid username and invalid password "wrong_password"
    Then I should see an error message for invalid login

    Given I am on the login page
    When I enter invalid username "invalid_user" and invalid password "wrong_password"
    Then I should see an error message for invalid login