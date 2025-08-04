using GerenciamentoDePessoas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePessoas.Data
{
    public class GerenciamentoPessoasContext : IdentityDbContext<Usuario>
    {
        public GerenciamentoPessoasContext(DbContextOptions<GerenciamentoPessoasContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var administrador = new IdentityRole
            {
                Id = "b36df00d-c9dd-4e00-be31-8bf524df992b",
                Name = "administrador",
                NormalizedName = "ADMINISTRADOR"
            };

            var operador = new IdentityRole
            {
                Id = "ab6dc1dd-2608-4768-b924-8978ad63a39c",
                Name = "operador",
                NormalizedName = "OPERADOR"
            };

            builder.Entity<IdentityRole>().HasData(administrador, operador);

            base.OnModelCreating(builder);
        }

    }
}
