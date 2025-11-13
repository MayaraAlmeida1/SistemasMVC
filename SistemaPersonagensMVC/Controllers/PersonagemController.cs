
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPersonagensMVC.Data;
using SistemaPersonagensMVC.Models;

namespace SistemaPersonagensMVC.Controllers
{
    public class PersonagemController : Controller
    {
        private readonly AppDbContext _context;

        public PersonagemController(AppDbContext contextConstrutor)
        {
            _context = contextConstrutor;
        }

        public async Task<IActionResult> Index()
        {
            var Lista = await _context.tabelaPersonagem.ToListAsync();
            return View(Lista);
        }

        public IActionResult Criar() => View();

        [HttpPost]
        public async Task<IActionResult> Criar(string nomeConstrutor, int nivelConstrutor, string tipoPersonagemConstrutor)
        {
            Personagem ? novoPersonagem = null;

            if(tipoPersonagemConstrutor == "Guerreiro")
            {
                novoPersonagem = new Guerreiro(nomeConstrutor, nivelConstrutor);
            }
            else if(tipoPersonagemConstrutor == "Mago")
            {
                novoPersonagem = new Mago(nomeConstrutor, nivelConstrutor);
            }
            else
            {
                return BadRequest("Personagem inválido.");
            }

            _context.tabelaPersonagem.Add(novoPersonagem);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Deletar(int id)
        {
            var Personagem = await _context.tabelaPersonagem.FindAsync(id);

            if(Personagem == null) return NotFound();

            _context.tabelaPersonagem.Remove(Personagem);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}