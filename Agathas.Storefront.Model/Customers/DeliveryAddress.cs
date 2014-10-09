using System;

namespace Agathas.Storefront.Model.Customers
{
    public class DeliveryAddress : Address
    {        
        public string Name { get; set; }
        public Customer Customer { get; set; }

        protected override void Validate()
        {
            base.Validate();

            if (String.IsNullOrEmpty(Name))
                base.AddBrokenRule(DeliveryAddressBusinessRules.NameRequired);

            if (Customer == null)
                base.AddBrokenRule(DeliveryAddressBusinessRules.CustomerRequired);
        }
    }
}
