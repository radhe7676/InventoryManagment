namespace InventoryManagmentAPI.DataAccess
{
    using InventoryManagmentAPI.DataAccess.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDataAccess
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product> GetProductAsync(int id);

        Task UpdateProductAsync(Product product);

        Task<int> AddProductAsync(Product product);

        Task<Product> DeleteProductAsync(int id);

        bool IsProductExists(int id);
    }
}
