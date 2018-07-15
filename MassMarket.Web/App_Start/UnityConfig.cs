using System.Web.Http;
using MassMarket.Domain.Repositories;
using MassMarket.Service;
using Unity;
using Unity.WebApi;

namespace MassMarket.Web {

  public static class UnityConfig {

    public static void RegisterComponents() {
      var container = new UnityContainer();

      container.RegisterType<IUnitOfWork, UnitOfWork>();

      container.RegisterType<IProductService, ProductService>();
      container.RegisterType<ICategoryService, CategoryService>();

      GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
    }
  }
}
