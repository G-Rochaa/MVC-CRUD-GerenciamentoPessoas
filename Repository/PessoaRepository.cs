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
            var pessoasBanco = await _context.Pessoas.ToListAsync();

            return pessoasBanco;
        }

        public async Task<Pessoa> BuscarPessoaPorIdAsync(int id)
        {
            try
            {
                var pessoa = await _context.Pessoas.AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (pessoa == null)
                {
                    throw new Exception("Usuário não encontrado.");
                }

                return pessoa;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> VerificarSePessoaExisteAsync(string cpf)
        {
            var pessoaExiste = await _context.Pessoas
                .AnyAsync(p => p.CPF == cpf);

            return pessoaExiste;
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

        public async Task<Pessoa> EditarPessoaAsync(Pessoa pessoa)
        {
            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();

            return pessoa;
        }

        public async Task DeletarPessoaAsync(Pessoa pessoa)
        {
            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> VerificarSeUsuarioExisteAsync(string cpf)
        {
            var usuarioExiste = await _context.Pessoas
                .AnyAsync(p => p.CPF == cpf);

            return usuarioExiste;
        }

        public async Task<int> BuscarTotalAsync()
        {
            return await _context.Pessoas.CountAsync();
        }

        public async Task<List<Pessoa>> BuscarPessoaNomeAsync(string termo)
        {
            var pessoasDb = await _context.Pessoas
            .Where(p => EF.Functions.Like(p.Nome, $"%{termo}%") ||
                        EF.Functions.Like(p.Sobrenome, $"%{termo}%") ||
                        EF.Functions.Like(p.CPF, $"%{termo}%"))
            .ToListAsync();

            return pessoasDb;
        }
    }
}
