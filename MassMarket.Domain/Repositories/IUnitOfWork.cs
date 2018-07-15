using System;
using System.Threading.Tasks;
using MassMarket.Domain.Entities;

namespace MassMarket.Domain.Repositories {

    public interface IUnitOfWork : IDisposable {

        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }
        Task<int> Complete();
    }
}