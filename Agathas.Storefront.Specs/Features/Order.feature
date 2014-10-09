Feature: Order
	In order to have my items to delivered
	As a customer
	I want to be able to create an order

Scenario: Create an Order
	Given I have an order but not paid for it	
	Then the order should be in an open state
	
Scenario: Pay for an order
	Given I have an order but not paid for it
	When I pay for it 	
	Then the order should be in an submitted state	

