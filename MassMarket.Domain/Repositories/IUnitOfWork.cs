using System;
using System.Threading.Tasks;

namespace MassMarket.Domain.Repositories {

    public interface IUnitOfWork : IDisposable {
        Task<int> Complete();
    }
}