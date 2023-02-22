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

        /// <summary>
        /// Traz os dados do contato pelo Id para preencher o formulario de edição
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult EditarContato(int Id)
        {
            ContatoModel contato = _contatoRepository.ListaPorId(Id);
            return View(contato);
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

        [HttpPost]
        public IActionResult AtualizaPorId(ContatoModel contato)
        {
            _contatoRepository.AtualizarContato(contato);

            return RedirectToAction("Index");
        }
    }
}
