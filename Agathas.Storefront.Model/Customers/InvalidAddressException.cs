using System;

namespace Agathas.Storefront.Model.Customers
{
    public class InvalidAddressException : Exception
    {
        public InvalidAddressException(string message)
            : base(message)
        {            
        }
    }
}