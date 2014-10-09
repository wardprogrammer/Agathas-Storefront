using System;
using System.Collections.Generic;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Services.Messaging.ProductCatalogueService
{
    public class GetFeaturedProductsResponse
    {
        public IEnumerable<ProductSummaryView> Products { get; set; }
    }
}
