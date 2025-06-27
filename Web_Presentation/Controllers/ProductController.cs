using App_Service_Layer.InterFaces;
using App_Service_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model_Layer.Entities;

namespace Web_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var product = await _productService.GetAllProductsAsync();
            return Ok(product);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) { return NotFound(); }
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Product product)
        {
            await _productService.AddProductAsync(product);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            await _productService.UpdateProductAsync(product);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok();
        }
    }
}
