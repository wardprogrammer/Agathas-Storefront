using System;
using System.Collections.Generic;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Controllers.ViewModels.ProductCatalogue
{
    public class ProductDetailView : BaseProductCataloguePageView 
    {
        public ProductView Product { get; set; }
    }
}