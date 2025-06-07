using GerenciamentoDePessoas.Models;
using GerenciamentoDePessoas.Repository;
using System.Threading.Tasks;

namespace GerenciamentoDePessoas.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoasRepository;

        public PessoaService(IPessoaRepository pessoasRepository)
        {
            _pessoasRepository = pessoasRepository;
        }

        public async Task<List<Pessoa>> BuscarTodosAsync()
        {
           var usuariosBanco = await _pessoasRepository.BuscarTodosAsync();

            return usuariosBanco;
        }

        public async Task<Pessoa> CriarPessoaAsync(Pessoa pessoa)
        {
            var usuarioExiste = await _pessoasRepository.VerificarSeUsuarioExisteAsync(pessoa.CPF);

            if (usuarioExiste)
            {
                throw new Exception("Usuário já está cadastrado no sistema");
            }

            var usuarioCriado = await _pessoasRepository.CriarPessoaAsync(pessoa);

            return usuarioCriado;
        }
    }
}
