using Microsoft.EntityFrameworkCore;
using WebApiHumanos.Entidades;

namespace WebApiHumanos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Humanos> Humanos { get; set; }
    }
}
