using Microsoft.EntityFrameworkCore;
using ProductSearch.Models;

namespace ProductSearch.Data
{
    public class ProductSearchDbContext:DbContext
    {
        public ProductSearchDbContext(DbContextOptions<ProductSearchDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

            // Add constructor to configure connection string etc.
       

    }
}
