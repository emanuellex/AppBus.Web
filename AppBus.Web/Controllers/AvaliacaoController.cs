using AppBus.Web.Models;
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

        [HttpPost]
        public IActionResult Cadastrar (Avaliacao avaliacao)
        {
            _context.Avaliacoes.Add(avaliacao);
            _context.SaveChanges();
            TempData["msg"] = "Sua avaliação cadastrada com sucesso";
            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public IActionResult Index()
        {
            var lista = _context.Avaliacoes.ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var avaliacao = _context.Avaliacoes.Find(id);
            return View(avaliacao);
        }
    }
}
