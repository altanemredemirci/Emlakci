using Emlakci.Entity;
using Emlakci.WEBAPI.Repositories.ProductRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("getProducts")]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productRepository.GetAllAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ProductDetail(int id)
        {
            var values = await _productRepository.GetByIdAsync(id);

            if (values == null)
            {
                return NotFound(); // Return 404 Not Found if the entity with the given ID is not found
            }

            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDetails details)
        {
            var result = await _productRepository.CreateProductAsync(details);

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> ProductDelete(int id)
        {
            await _productRepository.DeleteProductAsync(id);

            return NoContent();
        }


    }
}
