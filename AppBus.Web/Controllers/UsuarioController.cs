using AppBus.Web.Models;
using AppBus.Web.Persistencia;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppBus.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private BusContext _context;

        public UsuarioController(BusContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(String Pesquisa)
        {
            var lista = _context.Usuarios
                .Where(i => i.Email.Contains(Pesquisa) || Pesquisa == null)
                .ToList();
            ViewBag.total = _context.Usuarios.Count();
            return View(lista);

        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            TempData["msg"] = "Parabéns! seu cadastro foi finalizado com sucesso!";
            return RedirectToAction("Cadastrar");

        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var usuario = _context.Usuarios
                .Where(i => i.UsuarioId == id)
                .FirstOrDefault();

            return View(usuario);

        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
            TempData["msg"] = "Usuário foi autualizado com sucesso.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            TempData["msg"] = "Usuário removido do sistema.";
            return RedirectToAction("Index");
        }
    }
}
