using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Querying;
using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Services.Messaging.ProductCatalogueService;

namespace Agathas.Storefront.Services.Implementations
{
    public class ProductSearchRequestQueryGenerator
    {
        public static Query CreateQueryFor(GetProductsByCategoryRequest request)
        {
            Query productQuery = new Query();
            Query colourQuery = new Query();
            Query brandQuery = new Query();
            Query sizeQuery = new Query();

            colourQuery.QueryOperator = QueryOperator.Or;
            foreach (int id in request.ColourIds)            
                colourQuery.Add(Criterion.Create<Product>(p => p.Colour.Id, id, CriteriaOperator.Equal));            

            if (colourQuery.Criteria.Count() > 0)            
                productQuery.AddSubQuery(colourQuery);            

            brandQuery.QueryOperator = QueryOperator.Or;
            foreach (int id in request.BrandIds)            
                brandQuery.Add(Criterion.Create<Product>(p => p.Brand.Id, id, CriteriaOperator.Equal));            

            if (brandQuery.Criteria.Count() > 0)            
                productQuery.AddSubQuery(brandQuery);            

            sizeQuery.QueryOperator = QueryOperator.Or;
            foreach (int id in request.SizeIds)            
                sizeQuery.Add(Criterion.Create<Product>(p => p.Size.Id, id, CriteriaOperator.Equal));            

            if (sizeQuery.Criteria.Count() > 0)            
                productQuery.AddSubQuery(sizeQuery);          

            productQuery.Add(Criterion.Create<Product>(p => p.Category.Id, request.CategoryId, CriteriaOperator.Equal));
            return productQuery;
        }
    }
}
