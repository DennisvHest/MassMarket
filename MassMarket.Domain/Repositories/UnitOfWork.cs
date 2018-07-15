using System.Threading.Tasks;
using MassMarket.Domain.Entities;

namespace MassMarket.Domain.Repositories {

    public class UnitOfWork : IUnitOfWork {

        private readonly MassMarketContext _context;

        public IRepository<Product> Products { get; }
        public IRepository<Category> Categories { get; }

        public UnitOfWork(MassMarketContext context) {
            _context = context;

            Products = new ProductRepository(context);
            Categories = new CategoryRepository(context);
        }

        public async Task<int> Complete() {
            return await _context.SaveChangesAsync();
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}