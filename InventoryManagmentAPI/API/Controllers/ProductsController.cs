using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagmentAPI.DataAccess.Models;
using InventoryManagmentAPI.Application.Repositories;
using InventoryManagmentAPI.Infrastructure.Dtos;

namespace InventoryManagmentAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            return new ActionResult<IEnumerable<ProductDto>>(await productRepository.GetProductsAsync());
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await productRepository.GetProductAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDto product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    await productRepository.UpdateProductAsync(product);
                }
                else 
                {
                    return BadRequest();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productRepository.IsProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                var id = await productRepository.AddProductAsync(product);
                product.Id = id;

                return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDto>> DeleteProduct(int id)
        {
            var product = await productRepository.DeleteProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
    }
}
