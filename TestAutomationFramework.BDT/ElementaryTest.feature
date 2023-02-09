Feature: ElementaryTest
As a user interested in EPAM Company
I want to be able to review Header
In order to get information about Careers

@smoke
Scenario: Epam site - Header - Check Header
	Given I navigate to Landing Page of Epam site
	Then I check that Header is displayed

@smoke
Scenario: Epam site - Header - Careers - Hiring Locations - Check careers page
	Given I navigate to Landing Page of Epam site
	When I click the Hiring Locations link on Header
	Then I check the apply button is desplayed
