using Microsoft.EntityFrameworkCore;

namespace SiteTeste.Data
{
    public class BancoContext :DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) :base(options)
        {

        }
    }
}
