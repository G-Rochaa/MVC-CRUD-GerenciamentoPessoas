using GerenciamentoDePessoas.Models;
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

        public async Task<ActionResult> Index()
        {
            var todosUsuarios = await _pessoasService.BuscarTodosAsync();
            return View(todosUsuarios);
        }

        [HttpGet]
        public async Task<ActionResult> Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Criar(Pessoa pessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = await _pessoasService.CriarPessoaAsync(pessoa);
                    if (usuario != null)
                    {
                        TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                        return RedirectToAction("Index", "Pessoa");
                    }
                }
                return View(pessoa);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return View(pessoa);
            }

        }
    }
}
