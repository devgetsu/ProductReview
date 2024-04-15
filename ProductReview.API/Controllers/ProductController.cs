using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductReview.API.Attributes;
using ProductReview.Application.Services.ProductServices;
using ProductReview.Domain.DTOs;
using ProductReview.Domain.Entities.Enums;

namespace ProductReview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        //[IdentityFilter(Permission.GetProduct)]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        //[IdentityFilter(Permission.GetProduct)]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _productService.GetProductById(id);
                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        //[IdentityFilter(Permission.CreateProduct)]
        public async Task<IActionResult> CreateProduct([FromForm] ProductDTO productDTO)
        {
            try
            {
                var product = await _productService.CreateProduct(productDTO);
                return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        //[IdentityFilter(Permission.UpdateProduct)]
        public async Task<IActionResult> UpdateProductById([FromForm] int id, ProductDTO productDTO)
        {
            try
            {
                var updatedProduct = await _productService.UpdateProductById(id, productDTO);
                if (updatedProduct == null)
                    return NotFound();

                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        //[IdentityFilter(Permission.DeleteProduct)]

        public async Task<IActionResult> DeleteProductById(int id)
        {
            try
            {
                var result = await _productService.DeleteProductById(id);
                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
