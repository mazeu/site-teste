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

        public IActionResult ApagarContato(int Id)
        {
            //Traz a informação do contato que se quer apagar, mas nao apaga no banco
            ContatoModel contato = _contatoRepository.ListaPorId(Id);
            return View(contato);
        }
        public IActionResult ApagarContatoBanco(int Id)
        {
            try
            {
               bool apagado = _contatoRepository.Apagar(Id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemSucesso"] = "Não foi possivel apagar o contato!";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = "Contato não foi apagado! Verifique as informações, detalhe:" + e.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult CriarContato(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato criado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = "Contato não criado! Verifique as informações, detalhe:" + e.Message;
                return RedirectToAction("Index");
            }
           
        }

        [HttpPost]
        public IActionResult AtualizaPorId(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.AtualizarContato(contato);
                    TempData["MensagemSucesso"] = "Contato editado com sucesso!";
                    return RedirectToAction("Index");
                }

                return RedirectToAction("EditarContato", contato);
            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = "Contato não editado! Verifique as informações, detalhe:" + e.Message;
                return RedirectToAction("Index");
            }

        }
    }
}
