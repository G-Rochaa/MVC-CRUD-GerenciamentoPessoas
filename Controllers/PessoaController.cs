using GerenciamentoDePessoas.Models;
using GerenciamentoDePessoas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDePessoas.Controllers
{
    [Authorize]
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
            var todasPessoas = await _pessoasService.BuscarTodosAsync();
            return View(todasPessoas);
        }

        [HttpGet]
        public async Task<ActionResult> Total()
        {
            var totalPessoas = await _pessoasService.BuscarTotalAsync();
            return Ok(totalPessoas);
        }
        
        [HttpGet]
        public async Task<JsonResult> BuscarPessoasNome(string termo)
        {
            var resultadoBusca = await _pessoasService.BuscarPessoaNomeAsync(termo);

            return Json(resultadoBusca);
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

        [HttpGet]
        public async Task<ActionResult> Editar(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Um Id deve ser informado");
                }

                var pessoa = await _pessoasService.BuscarPessoaPorIdAsync(id);

                return View(pessoa);
            }
            catch (Exception ex)
            {

                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index", "Pessoa");
            }

        }

        [HttpPost]
        public async Task<ActionResult> Editar(Pessoa pessoa)
        {
            try
            {
                if (pessoa.Id == 0)
                {
                    throw new ArgumentException("Um Id deve ser informado");
                }

                var pessoaDb = await _pessoasService.EditarPessoaAsync(pessoa);


                TempData["MensagemSucesso"] = $"Pessoa {pessoa.Nome} foi atualizada com sucesso!";
                return RedirectToAction("Index", "Pessoa");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return View(pessoa);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Deletar(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Um Id deve ser informado");
                }

                await _pessoasService.DeletarPessoaAsync(id);

                TempData["MensagemSucesso"] = $"Pessoa Deletada!";
                return RedirectToAction("Index", "Pessoa");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return View();
            }
        }
    }
}
