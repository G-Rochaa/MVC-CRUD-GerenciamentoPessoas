using GerenciamentoDePessoas.Models;

namespace GerenciamentoDePessoas.Services
{
    public interface IPessoaService
    {
        Task<List<Pessoa>> BuscarTodosAsync();

        Task<int> BuscarTotalAsync();

        Task<Pessoa> CriarPessoaAsync(Pessoa pessoa);

        Task<Pessoa> BuscarPessoaPorIdAsync(int id);

        Task<Pessoa> EditarPessoaAsync(Pessoa pessoa);

        Task DeletarPessoaAsync(int id);

        Task<List<string>> BuscarPessoaNomeAsync(string termo);

    }
}
