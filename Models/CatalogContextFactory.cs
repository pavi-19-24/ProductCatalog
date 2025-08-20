using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Catalog.Web.Models
{
    public class CatalogContextFactory : IDesignTimeDbContextFactory<CatalogContext>
    {
        public CatalogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CatalogContext>();

            // Use your connection string here
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProductCatalogDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new CatalogContext(optionsBuilder.Options);
        }
    }
}
