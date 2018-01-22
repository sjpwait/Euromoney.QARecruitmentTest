Feature: Management Test Page
As a user
I want to click the ‘who we are’ --> ‘management team’ menu item
So that we can see that the correct page is displayed

@mytag
Scenario: Open Euro Money Management Page
	Given I have a browser
	And the browser is on EuroMoney
	When Navigate to management team
	Then we are taken to the correct page
	And each team member has a section
	| FullName            |
	| Andrew Rashbass     |
	| Diane Alfano        |
	| Bashar AL-Rehany    |
	| Tim Bratton         |
	| Raju Daswani        |
	| Christopher Fordham |
	| Gillian Fox         |
	| Rosalind Irving     |
	| Colin Jones         |
	| John Orchard        |
	| Aloisio Parente     |
	| Andrew Pieri        |
	| Jane Wilkinson      |
	| Danny Williams      |
	And each team member has Name
	And each team member has Job Title
	And each team member has Picture
	And each team member has Description
