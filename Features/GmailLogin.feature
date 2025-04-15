Feature: Verify Gmail Login functionality
  As a user, I want to log in to Gmail with valid and invalid credentials.

  #PositiveScenario
  Scenario: Login with valid credentials
    Given I navigate to Gmail login page
    When I enter valid email and password
    Then I should be logged in successfully
    
  #NegativeScenario
  Scenario: Login with invalid credentials
    Given I navigate to Gmail login page
    When I enter invalid email and password
    Then I  should see an error message

  @MultipleUsers
  Scenario Outline: Test login with multiple credentials
    Given I navigate to Gmail login page
    When I enter email "<email>" and password "<password>"
    Then I should be logged in successfully
    
 Examples:
      | email                    | password |
      | Selautomation81@gmail.com| Jesus123$|
      | testautom123@gmail.com   | Benji123$|
      