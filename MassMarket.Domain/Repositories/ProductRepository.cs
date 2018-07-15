using System.Data.Entity;
using MassMarket.Domain.Entities;

namespace MassMarket.Domain.Repositories {

    public class ProductRepository : Repository<Product> {

        public ProductRepository(MassMarketContext context) : base(context) { }
    }
}
