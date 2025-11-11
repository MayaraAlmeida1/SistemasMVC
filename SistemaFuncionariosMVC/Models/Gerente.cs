
namespace SistemaFuncionariosMVC.Models
{
    public class Gerente : Funcionario
    {
        public Gerente() { }

        public Gerente(string NomeConstrutor, double SalarioBaseConstrutor) : base(NomeConstrutor, SalarioBaseConstrutor) { }

        public override double CalcularSalario() => SalarioBase * 1.5;

    }
}