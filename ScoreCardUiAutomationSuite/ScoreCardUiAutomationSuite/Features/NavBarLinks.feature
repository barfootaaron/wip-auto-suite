Feature: NavBarLinks
	In order to verify our mock nav works as designed
	As a scorecard enthusiast
	I want to ensure the scorecard FPS logo links to FPS local dev login


Scenario: Verify nav link routes to correct page
	Given I am viewig the 'scorecard page'
	When I click on the 'FPS logo' in the nav
	Then I should be directed to the 'FPS local dev login page'