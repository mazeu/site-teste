using System.Collections.Generic;
using SiteTeste.Models;

namespace SiteTeste.Repository
{
    public interface IContatoRepository
    {
        ContatoModel ListaPorId(int Id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel AtualizarContato(ContatoModel contato);
        //ContatoModel AtualizaPorId(ContatoModel contato);
        bool Apagar(int Id);
    }
}
