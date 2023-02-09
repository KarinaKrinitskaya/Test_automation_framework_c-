Feature: BasicTests
As a user interested in EPAM Company
I want to be able to switch between pages

@tag1
Scenario: Epam site - Header - How we do it - Our work - Click back - Check the previous page
	Given I navigate to Landing Page of Epam site
	When I click the How we do it link on Header
	And I click the Our work
	And I click back
	Then I check the previous page
