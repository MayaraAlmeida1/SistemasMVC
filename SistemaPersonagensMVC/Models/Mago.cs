
namespace SistemaPersonagensMVC.Models
{
    public class Mago : Personagem
    {
        public Mago() { }

        public Mago(string nomeConstrutor, int nivelConstrutor) :base(nomeConstrutor, nivelConstrutor) { }

        public override int CalcularPoder()
        {
            return Nivel * 8 + 20;
        }
    }
}