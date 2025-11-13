
namespace SistemaAnimaisMVC.Models
{
    public class Elefante : Animal
    {
        public Elefante() { }

        public Elefante(string nomeConstrutor) :base(nomeConstrutor) { }

        public override string EmitirSom() => "Barrito";

        public override string TipoAlimentacao() => "Herbívoro";
    

    }
}