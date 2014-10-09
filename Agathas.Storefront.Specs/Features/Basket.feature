Feature: Basket
	In order to purchase products
    As a customer
    I want to be able to add products to my basket

Scenario: Add product to a Basket
	Given I have no products in my basket
	When I add a product to a basket worth 9 dollars 
	Then I should have a total of 1 product in my basket with a total worth of 9 dollars	
	
Scenario: Remove product from Basket
	Given I have a product in my basket
	When I remove that product 
	Then I should have a total of 0 products in my basket
	
Scenario: Add a product to the basket that already exisits in the basket
	Given I have a product in my basket
	When I add the same product  to the basket
	Then the qty of that product should increase by 1
	
	
