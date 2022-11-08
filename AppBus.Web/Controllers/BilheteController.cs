using AppBus.Web.Models;
using AppBus.Web.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var lista = _context.Usuarios.ToList();
            ViewBag.usuarioss = new SelectList(lista, "UsuarioId", "Email");
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
        public IActionResult Index(string Pesquisa)
        {
            var lista = _context.Bilhetes
                .Where(b => b.NomeTitular.Contains(Pesquisa) || Pesquisa == null)
                .ToList();
            ViewBag.total = _context.Bilhetes.Count();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var bilhete = _context.Bilhetes.Find(id);
            return View(bilhete);
        }

        [HttpPost]
        public IActionResult Editar (Bilhete bilhete)
        {
            _context.Bilhetes.Update(bilhete);
            _context.SaveChanges();
            TempData["msg"] = "Bilhete atualizado com sucesso";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            var bilhete= _context.Bilhetes.Find(id);
            _context.Bilhetes.Remove(bilhete);
            _context.SaveChanges();
            TempData["msg"] = "Bilhete foi removido do sistema.";
            return RedirectToAction("Index");
        }
    }

}

    