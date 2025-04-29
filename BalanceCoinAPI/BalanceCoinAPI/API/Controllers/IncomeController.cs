using BalanceCoinAPI.DTOs;
using BalanceCoinAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BalanceCoinAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeService _incomeService;

        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<IncomeDTO>>> GetAll()
        {
            var incomes = await _incomeService.GetAllIncomesAsync();
            return Ok(incomes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IncomeDTO>> GetById(int id)
        {
            var income = await _incomeService.GetIncomeByIdAsync(id);
            if (income == null)
                return NotFound();

            return Ok(income);
        }
        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IncomeDTO>> GetByCategory(int categoryId)
        {
            var incomes = await _incomeService.GetIncomesByCategoryAsync(categoryId);
            return Ok(incomes);
        }


        [HttpPost]
        public async Task<ActionResult<IncomeDTO>> Create(IncomeDTO incomeDto)
        {
            var newIncome = await _incomeService.CreateIncomeAsync(incomeDto);
            return CreatedAtAction(nameof(GetById), new { id = newIncome.Id }, newIncome);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IncomeDTO>> Update(int id, IncomeDTO incomeDto)
        {
            var updatedIncome = await _incomeService.UpdateIncomeAsync(id, incomeDto);
            if (updatedIncome == null)
                return NotFound();

            return Ok(updatedIncome);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _incomeService.DeleteIncomeAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
