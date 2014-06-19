using System.Web.Mvc;

namespace tattlr.services.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public string Test()
        {
            return "worked";
        }
    }
}