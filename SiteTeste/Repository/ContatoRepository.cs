using System.Collections.Generic;
using System.Linq;
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

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            //gravar no banco
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();//represents commit 
            return contato;
        }

        public ContatoModel ListaPorId(int Id)
        {
            return _bancoContext.Contatos.FirstOrDefault(b => b.Id == Id);
        }

        //public ContatoModel AtualizaPorId(ContatoModel contato)
        //{
        //    ContatoModel contatoDb = ListaPorId(contato.Id);

        //    if (contatoDb == null)
        //    {
        //        throw new System.Exception("Erro ao atualizar o contato.");
        //    }

        //    contatoDb.Nome = contato.Nome;
        //    contatoDb.Email = contato.Email;
        //    contatoDb.Celular = contato.Celular;

        //    _bancoContext.Update(contatoDb);
        //    _bancoContext.SaveChanges();

        //    return contatoDb;
        //}

        public ContatoModel AtualizarContato(ContatoModel contato)
        {
            ContatoModel contatoDb = ListaPorId(contato.Id);

            if (contatoDb == null)
            {
                throw new System.Exception("Erro ao atualizar o contato.");
            }

            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;

            _bancoContext.Update(contatoDb);
            _bancoContext.SaveChanges();

            return contatoDb;
        }

        public bool Apagar(int Id)
        {
            ContatoModel contatoDb = ListaPorId(Id);
            if (contatoDb == null)
            {
                throw new System.Exception("Erro ao deletar o contato.");
            }

            _bancoContext.Remove(contatoDb);
            _bancoContext.SaveChanges();

            return true;

        }
    }
}
