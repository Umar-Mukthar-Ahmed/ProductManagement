using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using Repository.Models;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        // Constructor to pass DbContextOptions to the base class
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply configuration for ProductType entity
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
        }
        // DbSet for Product entity
        public virtual DbSet<Product> Products { get; set; }

        // DbSet for ProductType entity
        public virtual DbSet<ProductType> ProductTypes { get; set; }
    }
}
