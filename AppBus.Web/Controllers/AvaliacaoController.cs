using AppBus.Web.Persistencia;
using Microsoft.AspNetCore.Mvc;

namespace AppBus.Web.Controllers
{
    public class AvaliacaoController : Controller
    {
            public BusContext _context;

            public AvaliacaoController(BusContext context)
            {
                _context = context;
            }

            [HttpGet]
            public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
