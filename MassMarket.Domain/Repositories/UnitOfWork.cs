using System.Threading.Tasks;

namespace MassMarket.Domain.Repositories {

    public class UnitOfWork : IUnitOfWork {

        private readonly MassMarketContext _context;

        public UnitOfWork(MassMarketContext context) {
            _context = context;
        }

        public async Task<int> Complete() {
            return await _context.SaveChangesAsync();
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}