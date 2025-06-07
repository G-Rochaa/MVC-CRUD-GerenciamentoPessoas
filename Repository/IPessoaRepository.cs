using GerenciamentoDePessoas.Models;

namespace GerenciamentoDePessoas.Repository
{
    public interface IPessoaRepository
    {
        Task<List<Pessoa>> BuscarTodosAsync();
        Task<bool> VerificarSeUsuarioExisteAsync(string cpf);
        Task<Pessoa> CriarPessoaAsync(Pessoa pessoa);
    }
}
