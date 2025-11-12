
namespace SistemaPersonagensMVC.Models
{
    public class Guerreiro : Personagem
    {
        public Guerreiro() { }

        public Guerreiro(string nomeConstrutor, int nivelConstrutor) :base(nomeConstrutor, nivelConstrutor) { }

        public override int CalcularPoder()
        {
            return Nivel * 10;
        }
    }
}