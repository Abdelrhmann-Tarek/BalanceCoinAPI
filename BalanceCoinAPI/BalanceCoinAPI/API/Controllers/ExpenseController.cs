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
        public async Task<ActionResult<ExpenceDTO>> GetAll()
        {
            var expense = await _expenseService.GetAllExpensesAsync();
            return Ok(expense);
        }
    }
}
