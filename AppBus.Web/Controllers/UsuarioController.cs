using Microsoft.AspNetCore.Mvc;

namespace AppBus.Web.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
