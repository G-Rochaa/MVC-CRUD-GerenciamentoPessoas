using GerenciamentoDePessoas.Data;
using GerenciamentoDePessoas.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePessoas.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly GerenciamentoPessoasContext _context;

        public PessoaRepository(GerenciamentoPessoasContext context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>> BuscarTodosAsync()
        {
            var usuariosBanco = await _context.Pessoas.ToListAsync();

            return usuariosBanco;
        }

        public async Task<bool> VerificarSeUsuarioExisteAsync(string cpf)
        {
            var usuarioExiste = await _context.Pessoas
                .AnyAsync(p => p.CPF == cpf);

            return usuarioExiste;
        }

        public async Task<Pessoa> CriarPessoaAsync(Pessoa pessoa)
        {
            try
            {
                await _context.Pessoas.AddAsync(pessoa);
                await _context.SaveChangesAsync();

                return pessoa;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar a pessoa no banco de dados. Verifique os dados informados e tente novamente.");
            }
       
        }
    }
}
