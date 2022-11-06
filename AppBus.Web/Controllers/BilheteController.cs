using Microsoft.AspNetCore.Mvc;

namespace AppBus.Web.Controllers
{
    public class BilheteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
