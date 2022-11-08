using AppBus.Web.Models;
using AppBus.Web.Persistencia;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            Usuarios();
            return View();
        }

        private void Usuarios()
        {
            var lista = _context.Usuarios.ToList();
            ViewBag.usuarioss = new SelectList(lista, "UsuarioId", "Email");
        }

        [HttpPost]
        public IActionResult Cadastrar(CartaoCredito cartaoCredito)
        {
            _context.Cartoes.Add(cartaoCredito);
            _context.SaveChanges();
            TempData["msg"] = "Seu cartão crédito foi cadastrado com sucesso!";
            return RedirectToAction("Cadastrar");
        }
        [HttpGet]
        public IActionResult Index(string Pesquisa)
        {
            var lista = _context.Cartoes
                .Where(c => c.NomeTitular.Contains(Pesquisa) || Pesquisa == null)
                .Include(c => c.Usuario)
                .ToList();
            ViewBag.total = _context.Cartoes.Count();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            Usuarios();
            var cartao = _context.Cartoes.Find(id);
            return View(cartao);
        }

        [HttpPost]
        public IActionResult Editar(CartaoCredito cartaoCredito)
        {
            _context.Cartoes.Update(cartaoCredito);
            _context.SaveChanges();
            TempData["msg"] = "Cartão de crédito atualizado com sucesso";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            var cartao = _context.Cartoes.Find(id);
            _context.Cartoes.Remove(cartao);
            _context.SaveChanges();
            TempData["msg"] = "Cartão de crédito foi removido do sistema.";
            return RedirectToAction("Index");
        }
    }
}

