Feature: NavBarExists
	In order to verify our mock nav is displayed as designed
	As a scorecard enthusiast
	I want to ensure the scorecard mock nav is displayed with the FPS logo 


Scenario: Verify nav is displayed
	Given I am logged in as a scorecard user
	When I view my 'scorecard page'
	Then I should see the 'scorecard nav' displayed with the FPS Logo
