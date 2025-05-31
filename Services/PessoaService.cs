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

        public async Task<List<Pessoa>> BuscarTodos()
        {
           var usuariosBanco = await _pessoasRepository.BuscarTodos();

            return usuariosBanco;
        }
    }
}
