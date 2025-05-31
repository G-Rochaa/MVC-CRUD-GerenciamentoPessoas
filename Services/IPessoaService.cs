using GerenciamentoDePessoas.Models;

namespace GerenciamentoDePessoas.Services
{
    public interface IPessoaService
    {
        Task<List<Pessoa>> BuscarTodos();

    }
}
