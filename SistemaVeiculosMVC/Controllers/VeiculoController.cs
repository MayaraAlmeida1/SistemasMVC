
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVeiculosMVC.Data;
using SistemaVeiculosMVC.Models;

namespace SistemaVeiculosMVC.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly AppDbContext _context;

        public VeiculoController(AppDbContext contextConstrutor)
        {
            _context = contextConstrutor;
        }

        public async Task<IActionResult> Index()
        {
            var Lista = await _context.TabelaVeiculo.ToListAsync();
            return View(Lista);
        }

        public IActionResult Criar() => View();

        [HttpPost]
        public async Task<IActionResult> Criar(string modeloConstrutor, int anoConstrutor, string tipoVeiculoConstrutor)
        {
            Veiculo? novoVeiculo = null;

            if(tipoVeiculoConstrutor == "Carro")
            {
                novoVeiculo = new Carro(modeloConstrutor, anoConstrutor);
            }
            else if(tipoVeiculoConstrutor == "Moto")
            {
                novoVeiculo = new Moto(modeloConstrutor, anoConstrutor);
            }
            else
            {
                return BadRequest("Tipo de veículo inválido!");
            }

            _context.TabelaVeiculo.Add(novoVeiculo);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Deletar(int id)
        {
            var Veiculo = await _context.TabelaVeiculo.FindAsync(id);

            if(Veiculo == null) return NotFound();

            _context.TabelaVeiculo.Remove(Veiculo);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}