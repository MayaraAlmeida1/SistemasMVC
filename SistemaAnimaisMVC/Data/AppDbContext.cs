using Microsoft.EntityFrameworkCore;
using SistemaAnimaisMVC.Models;

namespace SistemaAnimaisMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Animal> tabelaAnimal { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
            .HasDiscriminator<string>("Tipo")
            .HasValue<Leão>("Leão")
            .HasValue<Elefante>("Elefante");
        }
    }
}