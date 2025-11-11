
using System.ComponentModel.DataAnnotations;

namespace SistemaVeiculosMVC.Models
{
    public  abstract class Veiculo
    {
        [Key]
        public int Id { get; set; }
        public string Modelo { get; set; } = string.Empty;

        public int Ano { get; set; }

        public Veiculo() { }

        public Veiculo(string modeloConstrutor, int anoConstrutor)
        {
            Modelo = modeloConstrutor;
            Ano = anoConstrutor;
        }

        public abstract double CalcularRevisao();
    }
}