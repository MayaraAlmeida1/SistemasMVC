
namespace SistemaAnimaisMVC.Models
{
    public class Leão : Animal
    {
        public Leão() { }

        public Leão(string nomeConstrutor) :base(nomeConstrutor) { }

        public override string EmitirSom() => "Rugido";
        
        public override string TipoAlimentacao() => "Carnívoro";
    }
}