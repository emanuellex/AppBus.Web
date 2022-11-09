using AppBus.Web.Models;
using AppBus.Web.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            Usuarios();
            return View();
        }

        private void Usuarios()
        {
            var lista = _context.Usuarios.ToList();
            ViewBag.usuariosx = new SelectList(lista, "UsuarioId", "Email");
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
                 .Include(b => b.Usuario)
                .ToList();
            ViewBag.total = _context.Bilhetes.Count();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            Usuarios();
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

    