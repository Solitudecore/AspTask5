using AspTask5.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspTask5.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
              : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
