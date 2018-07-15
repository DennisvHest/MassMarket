using System.Data.Entity;
using System.Web.Http;
using System.Web.Routing;
using MassMarket.Domain;

namespace MassMarket.Web {

  public class MvcApplication : System.Web.HttpApplication {

    protected void Application_Start() {
      UnityConfig.RegisterComponents();
      GlobalConfiguration.Configure(WebApiConfig.Register);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
    }
  }
}
