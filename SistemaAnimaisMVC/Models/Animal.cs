
using System.ComponentModel.DataAnnotations;

namespace SistemaAnimaisMVC.Models
{
    public abstract class Animal
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public Animal() { }

        public Animal(string nomeConstrutor)
        {
            Nome = nomeConstrutor;
        }
        public abstract string EmitirSom();

        public abstract string TipoAlimentacao();
    }
}