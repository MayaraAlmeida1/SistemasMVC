
namespace SistemaVeiculosMVC.Models
{
    public class Moto : Veiculo
    {
        public Moto() { }
        public Moto(string modeloConstrutor, int anoConstrutor) :base(modeloConstrutor, anoConstrutor) { }

        public override double CalcularRevisao() => 300;
    }
}