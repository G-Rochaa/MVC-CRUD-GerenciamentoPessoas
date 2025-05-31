using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDePessoas.Controllers
{
    public class PessoaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
