using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Model.Customers;
using NUnit.Framework;

namespace Agathas.Storefront.Model.Tests
{
    [TestFixture()]
    public class EmailValidationSpecificationTest
    {
        [Test]
        public void An_Invalid_Email_Address_Will_Not_Satisfiy_The_Email_Validation_Specification()
        {
            string invalidEmailAddress = "gg@kkkkk";

            EmailValidationSpecification emailValidationSpecification = new EmailValidationSpecification();

            Assert.IsFalse(emailValidationSpecification.IsSatisfiedBy(invalidEmailAddress));
        }

        [Test]
        public void An_Empty_String_Will_Not_Satisfiy_The_Email_Validation_Specification()
        {
            string invalidEmailAddress = String.Empty;

            EmailValidationSpecification emailValidationSpecification = new EmailValidationSpecification();

            Assert.IsFalse(emailValidationSpecification.IsSatisfiedBy(invalidEmailAddress));
        }

        [Test]
        public void A_Valid_Email_Address_Will_Satisfiy_The_Email_Validation_Specification()
        {
            const string invalidEmailAddress = "scott@elbandit.co.uk";

            EmailValidationSpecification emailValidationSpecification = new EmailValidationSpecification();

            Assert.IsTrue(emailValidationSpecification.IsSatisfiedBy(invalidEmailAddress));
        }
    }
}
