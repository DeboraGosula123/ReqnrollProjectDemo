Feature: Login

Testing the login functionlity of an application

//Background: Given I navigate to login page 

@Login
Scenario: Test login with valid credentials

    Given I navigate to login page
	When I enter username and password
	And click on Login button
	Then I should be logged in successfully

@Login2
Scenario Outline: Test login with multiple credentials

    Given I navigate to login page
	When I choose <username> and <password>
	And click on Login button
	Then I should be logged in successfully

Examples:
	| username | password |
	| user1    | pass1    |
	| user2    | pass2    |
	| user3    | pass3    |
