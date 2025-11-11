
namespace SistemadeCursosMVC.Models
{
    public class Tecnico : Curso
    {
        //* métodos de sobrecarga
        public Tecnico() { }
        public Tecnico(string nomeConstrutor, int horasConstrutor) :base(nomeConstrutor, horasConstrutor) { }

        //* métodos de sobrescrita
        public override double CalcularPreco()
        {
            return Horas * 20;
        }
    }
}