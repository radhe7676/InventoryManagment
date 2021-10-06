namespace InventoryManagmentAPI.Application.Repositories
{
    using InventoryManagmentAPI.Infrastructure.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();

        Task<ProductDto> GetProductAsync(int id);

        Task UpdateProductAsync(ProductDto productDto);

        Task<int> AddProductAsync(ProductDto productDto);

        Task<ProductDto> DeleteProductAsync(int id);

        bool IsProductExists(int id);
    }
}
