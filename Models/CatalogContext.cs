using Microsoft.EntityFrameworkCore;

namespace Catalog.Web.Models
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Dress> Dresses { get; set; }
        public DbSet<AttributeDefinition> AttributeDefinitions { get; set; }
    }
}
