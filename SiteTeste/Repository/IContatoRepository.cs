using System.Collections.Generic;
using SiteTeste.Models;

namespace SiteTeste.Repository
{
    public interface IContatoRepository
    {
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
    }
}
