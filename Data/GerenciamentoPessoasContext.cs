using GerenciamentoDePessoas.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePessoas.Data
{
    public class GerenciamentoPessoasContext : DbContext
    {
        public GerenciamentoPessoasContext(DbContextOptions<GerenciamentoPessoasContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }

    }
}
