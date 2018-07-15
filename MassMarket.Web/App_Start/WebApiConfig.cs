using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MassMarket.Web {

  public static class WebApiConfig {

    public static void Register(HttpConfiguration config) {
      // Web API configuration and services

      // Web API routes
      config.MapHttpAttributeRoutes();

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );

      MediaTypeHeaderValue appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
      config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

      config.Formatters
        .JsonFormatter
        .SerializerSettings
        .ContractResolver = new CamelCasePropertyNamesContractResolver();

      config
        .Formatters
        .JsonFormatter
        .SerializerSettings
        .NullValueHandling = NullValueHandling.Ignore;
    }
  }
}
