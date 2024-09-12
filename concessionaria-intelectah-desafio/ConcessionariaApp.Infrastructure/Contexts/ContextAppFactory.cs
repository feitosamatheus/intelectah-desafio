using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ConcessionariaApp.Infrastructure.Contexts
{
    public class ContextAppFactory : IDesignTimeDbContextFactory<ContextApp>
    {
        public ContextApp CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextApp>();
            optionsBuilder.UseSqlServer("Server=tcp:helena-app.database.windows.net,1433;Initial Catalog=IntelecthDesafioDB;Persist Security Info=False;User ID=helena-user-azure;Password=Megaw@re21;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return new ContextApp(optionsBuilder.Options);
        }
    }
}
