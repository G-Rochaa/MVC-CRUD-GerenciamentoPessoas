using GerenciamentoDePessoas.Models;

namespace GerenciamentoDePessoas.Repository
{
    public interface IPessoaRepository
    {
        Task<List<Pessoa>> BuscarTodosAsync();

        Task<int> BuscarTotalAsync();

        Task<Pessoa> BuscarPessoaPorIdAsync(int id);

        Task<bool> VerificarSePessoaExisteAsync(string cpf);

        Task<Pessoa> CriarPessoaAsync(Pessoa pessoa);

        Task<Pessoa> EditarPessoaAsync(Pessoa pessoa);

        Task DeletarPessoaAsync(Pessoa pessoa);

        Task<List<Pessoa>> BuscarPessoaNomeAsync(string termo);
    }
}
