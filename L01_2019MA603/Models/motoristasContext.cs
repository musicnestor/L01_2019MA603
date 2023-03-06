using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace L01_2019MA603.Models
{
    public class motoristasContext : DbContext
    
    {
        public motoristasContext(DbContextOptions<clientesContext> options) : base(options)
        {

        }

        public DbSet<motoristas> motoristas { get; set; }

    }
}
