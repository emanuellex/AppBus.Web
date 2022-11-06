using AppBus.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AppBus.Web.Controllers
{
    public class CartaoCreditoController : Controller
    {

        public BusContext _context;

        public CartaoCreditoController(BusContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(CartaoCredito cartaoCredito)
        {
            _context.Cartoes.Add(cartaoCredito);
            _context.SaveChanges();
            TempData["msg"] = "Seu cartão foi cadastrado com sucesso!";
            return RedirectToAction("Cadastrar");
        }
    }
}
}
