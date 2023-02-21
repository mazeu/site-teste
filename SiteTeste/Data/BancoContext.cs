using Microsoft.EntityFrameworkCore;
using SiteTeste.Models;

namespace SiteTeste.Data
{
    public class BancoContext :DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) :base(options)
        {

        }

        public DbSet<ContatoModel> Contatos { get; set; }
    }
}
