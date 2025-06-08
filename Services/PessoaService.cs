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
           var pessoasBanco = await _pessoasRepository.BuscarTodosAsync();

            return pessoasBanco;
        }

        public async Task<Pessoa> BuscarPessoaPorIdAsync(int id)
        {
           return await _pessoasRepository.BuscarPessoaPorIdAsync(id);
        }

        public async Task<Pessoa> CriarPessoaAsync(Pessoa pessoa)
        {
            var pessoaExiste = await _pessoasRepository.VerificarSePessoaExisteAsync(pessoa.CPF);

            if (pessoaExiste)
            {
                throw new Exception("Pessoa já está cadastrado no sistema");
            }

            var pessoaCriada = await _pessoasRepository.CriarPessoaAsync(pessoa);

            return pessoaCriada;
        }

        public async Task<Pessoa> EditarPessoaAsync(Pessoa pessoa)
        {
            await _pessoasRepository.BuscarPessoaPorIdAsync(pessoa.Id);

            return await _pessoasRepository.EditarPessoaAsync(pessoa);
        }

        public async Task DeletarPessoaAsync(int id)
        {
            var pessoa = await _pessoasRepository.BuscarPessoaPorIdAsync(id);

            await _pessoasRepository.DeletarPessoaAsync(pessoa);
        }
    }
}
