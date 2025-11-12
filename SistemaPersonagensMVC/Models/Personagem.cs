
using System.ComponentModel.DataAnnotations;

namespace SistemaPersonagensMVC.Models
{
    public abstract class Personagem
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;
        public int Nivel { get; set; }

        public Personagem() { }

        public Personagem(string nomeConstrutor, int nivelConstrutor)
        {
            Nome = nomeConstrutor;
            Nivel = nivelConstrutor;
        }

        public abstract int CalcularPoder();    
    }
}