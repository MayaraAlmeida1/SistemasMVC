
using SistemaVeiculosMVC.Models;

namespace SistemaVeiculosMVC.Data 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options) { }

        public DbSet<Veiculo> TabelaVeiculo { get; set; }

        protected override void onModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veiculo>()
            .HasDiscriminator
        }
    }
}