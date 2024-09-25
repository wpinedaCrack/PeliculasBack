using Microsoft.EntityFrameworkCore;
using Models.Entidades;

namespace Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Persona> Personas { get; set; }
    }
}
