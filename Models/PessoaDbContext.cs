using Microsoft.EntityFrameworkCore;

namespace ApiCondominio.Models
{
    public class PessoaDbContext : DbContext
    {
        public PessoaDbContext(DbContextOptions<PessoaDbContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoa { get; set; }
    }
}