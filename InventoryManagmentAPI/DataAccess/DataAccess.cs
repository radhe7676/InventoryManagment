namespace InventoryManagmentAPI.DataAccess
{
    using InventoryManagmentAPI.DataAccess.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DataAccess : IDataAccess
    {
        private readonly InventoryDbContext inventoryDbContext;

        public DataAccess(InventoryDbContext inventoryDbContext)
        {
            this.inventoryDbContext = inventoryDbContext;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            try
            {
                return await inventoryDbContext.Products.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Product> GetProductAsync(int id)
        {
            try
            {
                return await inventoryDbContext.Products.FindAsync(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateProductAsync(Product product)
        {
            try
            {
                inventoryDbContext.Entry(product).State = EntityState.Modified;

                await inventoryDbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> AddProductAsync(Product product)
        {
            try
            {
                inventoryDbContext.Products.Add(product);
                await inventoryDbContext.SaveChangesAsync();

                return product.Id;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Product> DeleteProductAsync(int id)
        {
            try
            {
                var product = await inventoryDbContext.Products.FindAsync(id);

                if (product == null)
                {
                    return null;
                }

                inventoryDbContext.Products.Remove(product);
                await inventoryDbContext.SaveChangesAsync();

                return product;
            }
            catch
            {
                throw;
            }
        }

        public bool IsProductExists(int id)
        {
            try
            {
                return inventoryDbContext.Products.Any(e => e.Id == id);
            }
            catch
            {
                throw;
            }
        }
    }
}
