
using System.ComponentModel.DataAnnotations;

namespace SistemadeCursosMVC.Models
{
    public abstract class Curso
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty; //Começa nome como vazio

        public int Horas { get; set; }

        public Curso() { } // Cria primeiro um constrtutor vazio (sem parâmetros) para o banco não dar problemas

        public Curso(string nomeConstrutor, int horasConstrutor)
        {
            Nome = nomeConstrutor;
            Horas = horasConstrutor;
        }

        public abstract double CalcularPreco();
    }
}