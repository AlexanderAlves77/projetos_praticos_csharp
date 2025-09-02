using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace BrasilApiConnector.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // ⚠️ Connection string apenas para design-time (migrations)
            optionsBuilder
                .UseSqlServer("Server=localhost,1433;Database=EXEMPLO;User Id=brasil_user;Password=rska$1234;TrustServerCertificate=True;Encrypt=False;MultipleActiveResultSets=True;Connect Timeout=60;")
                .LogTo(Console.WriteLine, LogLevel.Information);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
