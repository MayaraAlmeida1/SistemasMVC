
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAnimaisMVC.Data;
using SistemaAnimaisMVC.Models;

namespace SistemaAnimaisMVC.Controllers
{
    public class AnimalController : Controller
    {
        private readonly AppDbContext _context;

        public AnimalController(AppDbContext contextController)
        {
            _context = contextController;
        }

        public async Task<IActionResult> Index()
        {
            var Lista = await _context.tabelaAnimal.ToListAsync();

            return View(Lista);
        }

        public IActionResult Criar() => View();

        [HttpPost]
        public async Task<IActionResult> Criar(string nomeConstrutor, string tipoAnimalConstrutor)
        {
            Animal? novoAnimal = null;

            if(tipoAnimalConstrutor == "Leão")
            {
                novoAnimal = new Leão(nomeConstrutor);
            }

            else if(tipoAnimalConstrutor == "Elefante")
            {
                novoAnimal = new Elefante(nomeConstrutor);
            }
            else
            {
                return BadRequest("Animal não encontrado.");
            }

            _context.tabelaAnimal.Add(novoAnimal);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Deletar(int id)
        {
            var animal = await _context.tabelaAnimal.FindAsync(id);

            if(animal == null) return NotFound();

            _context.tabelaAnimal.Remove(animal);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        } 
    }
}
