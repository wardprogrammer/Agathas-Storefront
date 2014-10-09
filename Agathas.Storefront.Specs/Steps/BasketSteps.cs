using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Basket;
using Agathas.Storefront.Model.Categories;
using Agathas.Storefront.Model.Products;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Agathas.Storefront.Specs.Steps
{
    [Binding]
    public class BasketSteps
    {
        private Basket _basket;                

        [Given(@"I have no products in my basket")]
        public void GivenIHaveNoProductsInMyBasket()
        {
            _basket = new Basket();
        }

        [Then(@"I should have a total of 1 product in my basket with a total worth of 9 dollars")]
        public void ThenIShouldHaveATotalOf1ItemsInABasketWithAWorthATotalOf9Dollars()
        {
            Assert.AreEqual(9.00m, _basket.BasketTotal);
            Assert.AreEqual(9.00m, _basket.ItemsTotal);
            Assert.AreEqual(1, _basket.Items().Count());
        }

        [When(@"I add a product to a basket worth 9 dollars")]
        public void WhenIAddAProductToABasketWorth9Dollars()
        {
            Product product = GetHatProduct();

            _basket.Add(product);
        }

        private Product GetHatProduct()
        {
            List<Product> products = new List<Product>();
            
            ProductTitle productTitle = new ProductTitle("Hat", 9.00m, new Brand(), new Category(), new ProductColour(),
                                                        products);

            Product product = new Product(productTitle, new ProductSize()) {Id = 1};

            products.Add(product);

            return product;
        }

        [Given(@"I have a product in my basket")]
        public void GivenIHaveAProductsInMyBasket()
        {
            _basket = new Basket();

            _basket.Add(GetHatProduct());
        }

        [Then(@"I should have a total of 0 products in my basket")]
        public void ThenIShouldHaveATotalOf0ItemsInMyBasket()
        {
            Assert.AreEqual(0,_basket.NumberOfItemsInBasket());
        }

        [When(@"I remove that product")]
        public void WhenIRemoveThatProductToABasket()
        {
            _basket.Remove(GetHatProduct());
        }

        [When(@"I add the same product  to the basket")]
        public void WhenIAddTheSameProductToTheBasket()
        {
            _basket.Add(GetHatProduct());
        }

        [Then(@"the qty of that product should increase by 1")]
        public void ThenTheQtyOfThatProductShouldIncreaseBy1()
        {
            Assert.AreEqual(2, _basket.GetItemFor(GetHatProduct()).Qty);
        }
      
    }    
}
