using AppBus.Web.Models;
using AppBus.Web.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppBus.Web.Controllers
{
    public class OnibusController : Controller
    {
        private BusContext _context;

        public OnibusController(BusContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Onibus onibus)
        {
            _context.Onibuss.Add(onibus);
            _context.SaveChanges();
            TempData["msg"] = "Parabéns! seu cadastro foi finalizado com sucesso!";
            return RedirectToAction("Cadastrar");

        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var onibus = _context.Onibuss
                .Include(i => i.TipoOnibus)
                .Where(i => i.OnibusId == id)
                .FirstOrDefault();

            return View(onibus);

        }

        [HttpPost]
        public IActionResult Editar(Onibus onibus)
        {
            _context.Onibuss.Update(onibus);
            _context.SaveChanges();
            TempData["msg"] = "Ônibus foi autualizado com sucesso";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Index(String Pesquisa)
        {
            var lista = _context.Onibuss
                .Where(i => i.Numero.Contains(Pesquisa) || Pesquisa == null)
                .Include(i => i.TipoOnibus)
                .ToList();
            ViewBag.total = _context.Onibuss.Count();
            return View(lista);

        }
        [HttpPost]
        public IActionResult Remover(int id)
        {
            var onibus = _context.Onibuss.Find(id);
            _context.Onibuss.Remove(onibus);
            _context.SaveChanges();
            TempData["msg"] = "Ônibus foi removido do sistema.";
            return RedirectToAction("Index");

        }

    
}
}
