using Microsoft.EntityFrameworkCore;

namespace Api_SistemaRegistroGastos.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) { }

        public DbSet<Gastos> Gastos { get; set; } 
    }
}
