using EFCoreOptimizer.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreOptimizer.Persistence.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
