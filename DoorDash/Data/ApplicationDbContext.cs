using Microsoft.EntityFrameworkCore;
using DoorDash.Models;

namespace DoorDash.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSets for your entities
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships, constraints, etc.
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Stores)
                .WithMany(s => s.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductStore",
                    j => j.HasOne<Store>().WithMany().HasForeignKey("StoreId"),
                    j => j.HasOne<Product>().WithMany().HasForeignKey("ProductId"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
