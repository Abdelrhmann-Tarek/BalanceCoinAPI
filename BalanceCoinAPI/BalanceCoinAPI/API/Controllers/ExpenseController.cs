using BalanceCoinAPI.DTOs;
using BalanceCoinAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BalanceCoinAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        public ExpenseController(IExpenseService expenseService)
        {
            expenseService = _expenseService;
        }
        [HttpGet]
        public async Task<ActionResult<ExpenseDTO>> GetAll()
        {
            var expense = await _expenseService.GetAllExpensesAsync();
            return Ok(expense);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseDTO>> GetById(int id)
        {
            var expense = await _expenseService.GetExpenseByIdAsync(id);
            if (expense == null) return NotFound();
            return Ok(expense);
        }
        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<ExpenseDTO>> GetByCategory(int categoryId)
        {
            var expense = await _expenseService.GetExpenseByCategoryIdAsync(categoryId);
            return Ok(expense);
        }
        [HttpPost]
        public async Task<ActionResult<ExpenseDTO>> Create(ExpenseDTO ExpenseDto)
        {
            var expense = await _expenseService.CreateExpenseAsync(ExpenseDto);
            return CreatedAtAction(nameof(GetById), new { id = expense.Id }, expense);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ExpenseDTO>> Update(int id, ExpenseDTO expenseDto)
        {
            var expense = await _expenseService.UpdateExpenseAsync(id, expenseDto);
            if (expense == null) return NotFound();
            return Ok(expense);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var expense = await _expenseService.DeleteExpenseAsync(id);
            if (!expense)
                return NotFound();

            return NoContent();


        }




    }
}
