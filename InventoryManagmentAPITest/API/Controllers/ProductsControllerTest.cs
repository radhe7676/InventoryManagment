namespace InventoryManagmentAPITest.API.Controllers
{
    using FakeItEasy;
    using InventoryManagmentAPI.API.Controllers;
    using InventoryManagmentAPI.Application.Repositories;
    using InventoryManagmentAPI.Infrastructure.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class ProductsControllerTest
    {
        private IProductRepository productRepository;

        public ProductsControllerTest()
        {
            this.productRepository = A.Fake<IProductRepository>();
        }

        [Fact]
        public async Task ShouldFechDataFromDatabase()
        {
            // Arrange
            var productsController = new ProductsController(productRepository);
            var testData = new List<ProductDto>()
            {
                GetProductDto()
            };

            IEnumerable<ProductDto> productDtos = testData;

            // Act 
            A.CallTo(() => productRepository.GetProductsAsync()).Returns(Task.FromResult(productDtos));

            var result = await productsController.GetProducts();

            // Assert
            Assert.Equal(productDtos, result.Value);
        }

        [Fact]
        public async Task ShouldFechDataFromDatabaseById()
        {
            // Arrange
            var productsController = new ProductsController(productRepository);
            var productDto = GetProductDto();

            // Act 
            A.CallTo(() => productRepository.GetProductAsync(A<int>._)).Returns(Task.FromResult(productDto));

            var result = await productsController.GetProduct(productDto.Id);

            // Assert
            Assert.Equal(productDto, result.Value);
        }

        [Fact]
        public async Task ShouldUpdateDataInDatabase()
        {
            // Arrange
            var productsController = new ProductsController(productRepository);
            var productDto = GetProductDto();

            // Act 
            A.CallTo(() => productRepository.GetProductAsync(A<int>._)).Returns(Task.FromResult(productDto));

            var result = await productsController.PutProduct(productDto.Id, productDto);

            // Assert
            A.CallTo(() => productRepository.UpdateProductAsync(productDto)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task ShouldSaveDataInDatabase()
        {
            // Arrange
            var productsController = new ProductsController(productRepository);
            var productDto = GetProductDto();

            // Act 
            A.CallTo(() => productRepository.AddProductAsync(A<ProductDto>._)).Returns(Task.FromResult(productDto.Id));

            var result = await productsController.PostProduct(productDto);

            // Assert
            Assert.Equal(null, result.Value);
        }

        private ProductDto GetProductDto()
        {
            return new ProductDto()
            {
                Id = 1,
                Description = "xyz",
                Discontinued = true,
                Name = "abc",
                Price = 12342,
                QuantityInReorder = 23,
                QuantityInStock = 2,
                ReorderLevel = 1,
                ReorderTimeInDays = 23,
                Value = 123
            };
        }
    }
}
