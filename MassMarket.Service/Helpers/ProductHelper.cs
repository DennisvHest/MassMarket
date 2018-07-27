using System.Collections.Generic;
using System.Linq;
using MassMarket.Domain.Entities;

namespace MassMarket.Service.Helpers {

    public enum ProductOrdering {
        Relevancy,
        PriceLowToHigh,
        PriceHighToLow
    }

    public static class ProductHelper {

        public static IOrderedQueryable<Product> OrderBy(this IQueryable<Product> products, ProductOrdering ordering) {
            switch (ordering) {
                case ProductOrdering.PriceLowToHigh:
                    return products.OrderBy(p => p.Price);
                case ProductOrdering.PriceHighToLow:
                    return products.OrderByDescending(p => p.Price);
                default: return (IOrderedQueryable<Product>)products;
            }
        }
    }
}
