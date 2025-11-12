using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemadeCursosMVC.Data;
using SistemadeCursosMVC.Models;

namespace SistemadeCursosMVC.Controllers
{
    public class CursoController : Controller // Controller (existe por trás dos panos)
    {
        private readonly AppDbContext _context; // _context é como se fosse o DbContext (parte de interação com banco)

        public CursoController(AppDbContext contextConstrutor)
        {
            _context = contextConstrutor;
        }

        //* Listar - [HttpGet] - Não é necssário colocar, pois por padrão ele já vem
        public async Task<IActionResult> Index() //IAactionResult - traz ações, nesse caso o Index() traz uma listagem
        {
            var Lista = await _context.TabelaCurso.ToListAsync();
            return View(Lista); // Retorna a lista de informações puxadas do banco
        }

        [HttpGet]  
        public IActionResult Criar() => View();  

        //* Criar
        [HttpPost] // Inserir informações
        public async Task<IActionResult> Criar(string nomeConstrutor, int horasConstrutor, string tipoCursoConstrutor) // QUando a ação for criar
        {
            Curso? novoCurso = null; // A ? - permite a inicialização vazia, como nula

            if(tipoCursoConstrutor == "Técnico")
            {
                novoCurso = new Técnico(nomeConstrutor, horasConstrutor);
            } 
            else if(tipoCursoConstrutor == "Superior")
            {
                novoCurso = new Superior(nomeConstrutor, horasConstrutor);
            }
            else
            {
                return BadRequest("Tipo de curso inválido!");
            }

            _context.TabelaCurso.Add(novoCurso); //Adicionar(Add) na TabelaCurso esse novo objeto criado por meio da conexão com o banco (_context)
            await _context.SaveChangesAsync(); // Salva essa adição no banco de dados

            return RedirectToAction("Index"); // Retorna a tabela index que traz uma listagem
        }

        //* Excluir
        public async Task<IActionResult> Deletar(int id) // Para deletar precisa passar o id
        {
            var Curso = await _context.TabelaCurso.FindAsync(id); // Find - procura um  registro dentro do banco por meio de um parâmetro, nesse caso o id

            if(Curso == null) return NotFound(); // Retorna que o registro (curso) não foi encontrado

            _context.TabelaCurso.Remove(Curso); // Caso encontre, vai remover o curso(registro) da tabela
            await _context.SaveChangesAsync(); // Salva alterações

            return RedirectToAction("Index");
        }
    }
}