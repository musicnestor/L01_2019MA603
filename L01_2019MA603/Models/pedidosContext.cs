using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace L01_2019MA603.Models
{
    public class pedidosContext: DbContext
    {
        public pedidosContext(DbContextOptions<pedidosContext> options) : base(options)
        {

        }

        public DbSet<pedidos> pedidos { get; set;}
    }
}
