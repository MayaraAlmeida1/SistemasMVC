
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

        public IActionResult Ciar => View();

        [HttpPost]

        public async Task<IActionResult> Criar(string nomeConstrutor, int nivelConstrutor, string tipoPersonagemConstrutor)
        {
            Personagem ? novoPersonagem = null;
        }
    }
}