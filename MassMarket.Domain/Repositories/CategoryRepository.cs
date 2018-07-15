using System.Data.Entity;
using MassMarket.Domain.Entities;

namespace MassMarket.Domain.Repositories {

    public class CategoryRepository : Repository<Category> {
        public CategoryRepository(DbContext context) : base(context) { }
    }
}
