namespace InventoryManagmentAPI.DataAccess.Models
{
    using Microsoft.EntityFrameworkCore;

    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
