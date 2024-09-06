using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ConcessionariaApp.Infrastructure.Contexts
{
    public class ContextAppFactory : IDesignTimeDbContextFactory<ContextApp>
    {
        public ContextApp CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextApp>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-6F7Q82U\\SQLEXPRESS;Initial Catalog=ConcessionariaDatabase;Integrated Security=True; TrustServerCertificate=True;");

            return new ContextApp(optionsBuilder.Options);
        }
    }
}
