using App_Service_Layer.InterFaces;
using App_Service_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model_Layer.Entities;

namespace Web_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var category = await _categoryService.GetAllCategoriesAsync();
            return Ok(category);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null) { return NotFound(); }
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Category category)
        {
            await _categoryService.AddCategoryAsync(category);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Category category)
        {
            await _categoryService.UpdateCategoryAsync(category);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok();
        }
    }
}
