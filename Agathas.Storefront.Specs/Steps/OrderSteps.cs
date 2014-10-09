using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain.Events;
using Agathas.Storefront.Model.Categories;
using Agathas.Storefront.Model.Orders;
using Agathas.Storefront.Model.Orders.Events;
using Agathas.Storefront.Model.Orders.States;
using Agathas.Storefront.Model.Products;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Agathas.Storefront.Specs.Steps
{
    [Binding]
    public class OrderSteps
    {
        public Order _order;
        private Product _product;


        public OrderSteps()
        {
            DomainEvents.DomainEventHandlerFactory = new StubDomaubinEventHandlerFactory();                        
        }

        [Given(@"I have an order but not paid for it")]
        public void GivenIHaveAnOrderButNotPaidForIt()
        {
            _order = new Order();

            ProductTitle productTitle = new ProductTitle("Hat", 9.00m, new Brand(), new Category(), new ProductColour(),
                                                         new List<Product> {_product});

            _product = new Product(productTitle, new ProductSize());
            
            _order.AddItem(_product, 1);
        }

        [Then(@"the order should be in an open state")]
        public void ThenTheOrderShouldBeInAnOpenState()
        {
            Assert.AreEqual(OrderStates.Open.Status, _order.Status);
        }

        [Then(@"the order should be in an submitted state")]
        public void ThenTheOrderShouldBeInAnSubmittedState()
        {
            Assert.AreEqual(OrderStates.Submitted.Status, _order.Status);
        }

        [When(@"I pay for it")]
        public void WhenIPayForIt()
        {
            Payment payment = new Payment(DateTime.Now, "fffljhkjkj", "PayPal", _product.Price);
                        
            _order.SetPayment(payment);
        }              
    }
}
