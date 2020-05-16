using Microsoft.EntityFrameworkCore;

namespace DesafioDotNetCoreBackEnd.Models
{
    public class CadastroDbContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        public CadastroDbContext(DbContextOptions<CadastroDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>().HasIndex(p => p.Nome).IsUnique();
        }
    }
}