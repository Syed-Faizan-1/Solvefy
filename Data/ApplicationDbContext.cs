using Microsoft.EntityFrameworkCore;
using Product_Inventory.Models;

namespace Product_Inventory.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Car", Description = "Brand New Car", Price = 20000, Quantity = 20 },
                new Product { Id = 2, Name = "Bike", Description = "Brand New Bike", Price = 20000, Quantity = 20 },
                new Product { Id = 3, Name = "Bicycle", Description = "Brand New Bicycle", Price = 20000, Quantity = 20 },
                new Product { Id = 4, Name = "Truck", Description = "Brand New Truck", Price = 20000, Quantity = 20 }

            );
        }
    }
}
