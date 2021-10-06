using AutoMapper;
using InventoryManagmentAPI.DataAccess;
using InventoryManagmentAPI.DataAccess.Models;
using InventoryManagmentAPI.Infrastructure.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagmentAPI.Application.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataAccess dataAccess;
        private readonly IMapper mapper;
        public ProductRepository(IDataAccess dataAccess, IMapper mapper)
        {
            this.dataAccess = dataAccess;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            try
            {
                var products = await dataAccess.GetProductsAsync();

                if (products != null)
                {
                    return mapper.Map<IEnumerable<ProductDto>>(products);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductDto> GetProductAsync(int id)
        {
            try
            {
                var product = await dataAccess.GetProductAsync(id);

                if(product != null)
                {
                    return mapper.Map<ProductDto>(product);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateProductAsync(ProductDto productDto)
        {
            try
            {
                var product = mapper.Map<Product>(productDto);

                await dataAccess.UpdateProductAsync(product);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> AddProductAsync(ProductDto productDto)
        {
            try
            {
                var product = mapper.Map<Product>(productDto);
                return await dataAccess.AddProductAsync(product);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductDto> DeleteProductAsync(int id)
        {
            try
            {
                var product = await dataAccess.DeleteProductAsync(id);
                if (product != null)
                {
                    return mapper.Map<ProductDto>(product);
                }
                else
                {
                    return null;
                }
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
                return dataAccess.IsProductExists(id);
            }
            catch
            {
                throw;
            }
        }
    }
}
