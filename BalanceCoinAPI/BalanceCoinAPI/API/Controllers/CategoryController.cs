using BalanceCoinAPI.Application.Interfaces;
using BalanceCoinAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BalanceCoinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase //adding controllers to handle HTTP requests
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;


            
        public CategoryController(ICategoryService categoryService,ILogger<CategoryController>logger)
        {
            _categoryService = categoryService;
            _logger = logger;

        }

        [HttpGet("Browse")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategories()
        {
            _logger.LogInformation("Getting All Categories request");
            var categories = await _categoryService.GetAllCategoriesAsync();
            if (categories == null)
            {
                _logger.LogWarning("No Categorise Found");
                return NotFound("Ther's No Categories");
            }
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound();
            return  (category);
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

