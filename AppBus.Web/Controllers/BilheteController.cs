using AppBus.Web.Models;
using AppBus.Web.Persistencia;
using Microsoft.AspNetCore.Mvc;

namespace AppBus.Web.Controllers
{
    public class BilheteController : Controller
    {
        public BusContext _context { get; set; }

        public BilheteController(BusContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public  IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastar(Bilhete bilhete)
        {
            _context.Bilhetes.Add(bilhete);
            _context.SaveChanges();
            TempData["msg"] = "Bilhete cadastrado com sucesso";
            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public IActionResult Index()
        {
            var lista = _context.Bilhetes.ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var bilhete = _context.Bilhetes.Find(id);
            return View(bilhete);
        }
    }

}

    