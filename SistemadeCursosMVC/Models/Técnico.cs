
namespace SistemadeCursosMVC.Models
{
    public class Técnico : Curso
    {
        //* métodos de sobrecarga
        public Técnico() { }
        public Técnico(string nomeConstrutor, int horasConstrutor) :base(nomeConstrutor, horasConstrutor) { }

        //* métodos de sobrescrita
        public override double CalcularPreco()
        {
            return Horas * 20;
        }
    }
}