using GerenciamentoDePessoas.Models;

namespace GerenciamentoDePessoas.Services
{
    public interface IPessoaService
    {
        Task<List<Pessoa>> BuscarTodosAsync();
        Task<Pessoa> CriarPessoaAsync(Pessoa pessoa);

    }
}
