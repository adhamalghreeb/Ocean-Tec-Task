using Microsoft.AspNetCore.Mvc;
using Ocean_Tec_Task.Models;
using Ocean_Tec_Task.Service;
using Ocean_Tec_Task.Service.Contracts;
using Ocean_Tec_Task.Shared;
using System.Net;

namespace Ocean_Tec_Task.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET api/products
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        // GET api/products/{productId}
        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductDto>> GetProductById(Guid productId)
        {
            var product = await _productService.GetProductByIdAsync(productId);

            if (product == null)
            {
                return NotFound(); // Return 404 Not Found if the product is not found
            }

            return Ok(product);
        }

        // POST api/products
        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] ProductDto productDto)
        {
            var createdProduct = await _productService.CreateProductAsync(productDto);

            return CreatedAtAction(nameof(GetProductById), new { productId = createdProduct.Id }, createdProduct);
        }

        // PUT api/products/{productId}
        [HttpPut("{productId}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(Guid productId, [FromBody] ProductDto updatedProductDto)
        {
            try
            {
                var updatedProduct = await _productService.UpdateProductAsync(productId, updatedProductDto);
                return Ok(updatedProduct);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // Return 404 Not Found if the product is not found
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Return 400 Bad Request if there's an issue with the request
            }
        }

        // DELETE api/products/{productId}
        [HttpDelete("{productId}")]
        public async Task<ActionResult> DeleteProduct(Guid productId)
        {
            var result = await _productService.DeleteProductAsync(productId);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                return NoContent(); // Return 204 No Content if the delete is successful
            }
            else if (result.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(result.Content.ReadAsStringAsync().Result); // Return 404 Not Found with the error message
            }

            return StatusCode((int)result.StatusCode); // Return other status codes as is
        }

        [HttpPost("createProductWithUnitsAndChars")]
        public async Task<IActionResult> CreateProductWithUnitsAndCharsAsync([FromBody] CreateProductWithUnitsAndCharsRequest request)
        {
            try
            {
                // Use the ProductService to create a product with units and characteristics
                var createdProductDto = await _productService.CreateProductWithUnitsAndCharsAsync(
                    request.ProductDto, request.MainUnitDto, request.MediumUnitDto, request.SmallUnitDto, request.CharacteristicsDto);

                // Return the created product DTO
                return Ok(createdProductDto);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an error response
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }

}
