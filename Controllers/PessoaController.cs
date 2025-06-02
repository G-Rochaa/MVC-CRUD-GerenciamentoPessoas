using GerenciamentoDePessoas.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDePessoas.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaService _pessoasService;

        public PessoaController(IPessoaService pessoasService)
        {
            _pessoasService = pessoasService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var todosUsuarios = await _pessoasService.BuscarTodos();
            return View(todosUsuarios);
        }

        [HttpGet]
        public async Task<ActionResult> Criar()
        {
            return View();
        }
    }
}
