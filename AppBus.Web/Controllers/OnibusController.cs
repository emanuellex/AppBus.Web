using Microsoft.AspNetCore.Mvc;

namespace AppBus.Web.Controllers
{
    public class OnibusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
