using BalanceCoinAPI.Application.Services;
using BalanceCoinAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BalanceCoinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase //adding controllers to handle HTTP requests
    {
        private readonly ICategoryService _categoryService;


        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> CreateCategory(CategoryDTO categoryDto)
        {
            var created = await _categoryService.CreateCategoryAsync(categoryDto);
            return CreatedAtAction(nameof(GetCategoryById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDTO>> UpdateCategory(int id, CategoryDTO categoryDto)
        {
            var updated = await _categoryService.UpdateCategoryAsync(id, categoryDto);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}

