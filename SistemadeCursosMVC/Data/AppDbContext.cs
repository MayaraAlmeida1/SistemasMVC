//* Pasta Data criada para guardar os arquivos de conexão com o banco de dados 

using Microsoft.EntityFrameworkCore;
using SistemadeCursosMVC.Models;

namespace SistemadeCursosMVC.Data
{
    public class AppDbContext : DbContext  // DbContext (existe por trás dos panos) auxilia na integração com o banco de dados
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } // Construtor recebendo as opções de configuração do banco

        public DbSet<Curso> TabelaCurso { get; set; } // Está direcionando a classe Curso para a TabelaCurso no banco de dados

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Sobscrevendo o metódo padrão já criado pelo mvc
        {
            modelBuilder.Entity<Curso>()
            .HasDiscriminator<string>("Tipo") // Ele separa as classes por Tipo
            .HasValue<Tecnico>("Técnico") // Quando o valor for da classe "Tecnico" ele joga para o "Tipo Técnico"
            .HasValue<Superior>("Superior");
        }
    }
}