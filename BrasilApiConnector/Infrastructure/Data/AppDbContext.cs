using Microsoft.EntityFrameworkCore;
using BrasilApiConnector.Models;

namespace BrasilApiConnector.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<CepInfo> Ceps => Set<CepInfo>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chave primária
            modelBuilder.Entity<CepInfo>().HasKey(c => c.Id);

            modelBuilder.Entity<CepInfo>().HasIndex(c => c.Cep).IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
