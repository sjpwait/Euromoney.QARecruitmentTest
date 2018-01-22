Feature:IJ Global Tests
As a user
I want to go to the ‘Our Portfolio’ --> ‘Pricing, data and market intelligence’ menu item
So that I can open the IJ Global website and see the latest news section

Scenario: Open IJ Global Page
	Given I have a browser
	And the browser is on EuroMoney
	When I Navigate to IJ Global Page
	Then the Url is https://ijglobal.com/
	And the Page Title is 'IJGlobal | Infrastructure Journal and Project Finance Magazine'
	And the league table is displayed
	And the menu shows the 'Specialist finance and economic data' link
