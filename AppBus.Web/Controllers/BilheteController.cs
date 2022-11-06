using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AppBus.Web.Controllers
{
    public class BilheteController : Controller
    {
        public class BilheteUnicoController : Controller
        {
            public BusContext _context;

            public BilheteUnicoController(BusContext context)
            {
                _context = context;
            }

            [HttpGet]
            public IActionResult Cadastrar()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Cadastrar(Bilhete bilhete)
            {
                _context.Bilhetes.Add(bilhete);
                _context.SaveChanges();
                TempData["msg"] = "Seu bilhete foi cadastrado com sucesso!";
                return RedirectToAction("Cadastrar");
            }
        }
    }
}
