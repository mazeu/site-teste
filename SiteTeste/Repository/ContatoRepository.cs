using SiteTeste.Data;
using SiteTeste.Models;

namespace SiteTeste.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            //gravar no banco
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();//represents commit 
            return contato;
        }
    }
}
