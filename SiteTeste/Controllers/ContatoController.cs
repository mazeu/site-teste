using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SiteTeste.Models;
using SiteTeste.Repository;

namespace SiteTeste.Controllers
{
    public class ContatoController : Controller
    {

        public readonly IContatoRepository _contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }
        public IActionResult Index()
        {
            List<ContatoModel> ListaContatos= _contatoRepository.BuscarTodos();

            return View(ListaContatos);
        }

        public IActionResult CriarContato()
        {
            return View();
        }

        public IActionResult EditarContato()
        {
            return View();
        }

        public IActionResult ApagarContato()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CriarContato(ContatoModel contato)
        {
            _contatoRepository.Adicionar(contato);

            return RedirectToAction("Index");
        }


    }
}
