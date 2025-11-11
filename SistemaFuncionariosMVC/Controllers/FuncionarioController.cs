using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaFuncionariosMVC.Data;
using SistemaFuncionariosMVC.Models;

namespace SistemaFuncionariosMVC.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly AppDbContext _context;

        public FuncionarioController(AppDbContext contextConstrutor)
        {
            _context = contextConstrutor;
        }

        // LISTAR
        // async / await -> executa a função de listar dentro do banco, mas permite que o sistema continue rodando enquanto isso acontece.

        public async Task<IActionResult> Index()
        {
            // ToList - lista as informações dentro da tabela funcionário.
            var lista = await _context.TabelaFuncionario.ToListAsync();

            // retorna a view com a lista de funcionários no index.
            return View(lista);
        }

        // Formulário de criação - retorna a lista de formulário vazia
        [HttpGet] // GET - Listar (Como se fosse um SELECT no banco)
        public IActionResult Criar() => View();

        // Cadastrar as informações do formulário no banco de dados.
        [HttpPost]
        public async Task<IActionResult> Criar(string NomeConstrutor, double SalarioBaseConstrutor, string CargoConstrutor)
        {
            Funcionario? novoFuncionario = null;

            if (CargoConstrutor == "Gerente")
            {
                novoFuncionario = new Gerente(NomeConstrutor, SalarioBaseConstrutor);
            }
            else if (CargoConstrutor == "Vendedor")
            {
                novoFuncionario = new Vendedor(NomeConstrutor, SalarioBaseConstrutor);
            }
            else
            {
                return BadRequest("Cargo inválido.");
            }

            _context.TabelaFuncionario.Add(novoFuncionario);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // Excluir
        public async Task<IActionResult> Deletar(int id)
        {
            // variável que vai armazenar o registro de funcionário encontrado pelo id.
            // Find(id) -> busca o registro pelo id
            var funcionario = await _context.TabelaFuncionario.FindAsync(id);

            if (funcionario == null) return NotFound();

            // Remove() -> remove o registro do banco.
            _context.TabelaFuncionario.Remove(funcionario);

            // Salva as alterações
            await _context.SaveChangesAsync();

            // Retorna para a Action: Index -> Mostra a lista atualizada de funcionários.
            return RedirectToAction("Index");
        }

    }
}