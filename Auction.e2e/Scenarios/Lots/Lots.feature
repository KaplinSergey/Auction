Feature: Facilities
	As an User
	I want to deal with the list of lots

@smoke @C1	
Scenario: Verify lots list has showen
	Given I am logged in as "User" in Auction
	When I visit "Lot/Index"
	#When I set key-value information on the page
	
