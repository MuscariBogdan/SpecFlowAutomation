Feature: Login

@login
Scenario: Successful login
Given I am on the login page
When I enter my username and password
Then I should be logged in