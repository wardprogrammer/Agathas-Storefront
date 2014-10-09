using System;
using System.Collections.Generic;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Controllers.ViewModels.ProductCatalogue
{
    public class HomePageView : BaseProductCataloguePageView 
    {
        public IEnumerable<ProductSummaryView> Products { get; set;}
    }
}
