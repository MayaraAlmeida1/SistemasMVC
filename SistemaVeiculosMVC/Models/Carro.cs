
namespace SistemaVeiculosMVC.Models
{
    public class Carro : Veiculo
    {
        public Carro() { }
        public Carro(string modeloConstrutor, int anoConstrutor) :base(modeloConstrutor, anoConstrutor) { }

        public override double CalcularRevisao() => 500; // Retorna (=>) 500
    }
}