using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MassMarket.Web.Startup))]

namespace MassMarket.Web {
  public class Startup {
    public void Configuration(IAppBuilder app) {
      app.Use(async (context, next) => {
        await next();

        if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value)) {
          context.Request.Path = new PathString("/Content/index.html");
          await next();
        }
      });
    }
  }
}
