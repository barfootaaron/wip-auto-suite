Feature: ExampleFeatureFile
	In order to ensure something
	As a scorecard user
	I want ensure that this feature works

Scenario: Worksheet button brings up Worksheet modal for SC users
	Given I am logged as a 'Loan Officer' 
	And viewing my 'Scorecard'
	When I click the 'Worksheet' button
	Then I should see 'Worksheet' modal



Scenario Outline: Test nav buttons display correct modal
	Given I am logged in as '<userType>'
	And I am on my '<startView>' view
	When I click the '<action>' button in the nav
	Then I should see the '<action>' modal appear

	Examples: 
    | userType     | startView | action       |
    | Admin        | home      | add note     |
    | Admin        | settings  | add reminder |
    | Loan Officer | home      | add note     |

