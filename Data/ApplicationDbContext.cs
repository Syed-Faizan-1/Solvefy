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
    }
}
