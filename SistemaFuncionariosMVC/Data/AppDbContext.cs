using Microsoft.EntityFrameworkCore;
using SistemaFuncionariosMVC.Models;

namespace SistemaFuncionariosMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        // recebe as opções de configuração do banco

        // direciona a classe (Funcionario) para a tabela (TabelaFuncionario)
        public DbSet<Funcionario> TabelaFuncionario { get; set; }

        // sobrescrever o mapeamento do modelo (uma unica tabela para funcionários)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>() // começa a configurar a entidade base Funcionario
            .HasDiscriminator<string>("Cargo") // cria uma única tabela, diferenciando Gerente e Vendedor por cargo
            .HasValue<Gerente>("Gerente") // quando a instancia for gerente, grava "gerente" em cargo
            .HasValue<Vendedor>("Vendedor"); // quando a instancia for vendedor, grava "vendedor" em cargo
        }
    }
}