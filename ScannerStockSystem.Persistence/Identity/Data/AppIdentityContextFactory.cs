using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ScannerStockSystem.Persistence.Identity.Data
{
  

    public class AppIdentityContextFactory : IDesignTimeDbContextFactory<AppIdentityContext>
    {
        public AppIdentityContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppIdentityContext>();

            // Configure the options (e.g., connection string, provider) for the context.
            // For example, using a connection string from appsettings.json:
            optionsBuilder.UseSqlServer("Data Source=odesydevqa.database.windows.net;Initial Catalog=Test");

            // Return a new instance of the context with the configured options.
            return new AppIdentityContext(optionsBuilder.Options);
        }
    }
}
