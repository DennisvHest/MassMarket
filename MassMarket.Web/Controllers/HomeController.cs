using System.Web.Mvc;

namespace MassMarket.Web.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return File("~/Content/index.html", "text/html");
        }
    }
}
