Feature: NewTest
As a user interested in EPAM site
I want to be able to view all sections on the page

Scenario: Epam site - Header - Services - Check Sections on services page
	Given I navigate to Landing Page of Epam site
	When I click the Services link on Header
	Then I check all sections is displayed
