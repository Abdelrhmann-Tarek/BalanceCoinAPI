using BalanceCoinAPI.Application.Services;
using BalanceCoinAPI.DTOs;
using BalanceCoinAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BalanceCoinAPI.Application.Services
{
    public class ExpenseService: IExpenseService
    {
        private readonly ApplicationDBContext _context;

        public ExpenseService(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<ExpenceDTO> CreateExpenseAsync(ExpenceDTO expenseDto)
            var expense = new Expense
            {
                Title = expenseDto.Title,
                Amount = expenseDto.Amount,
                CategoryId = expenseDto.CategoryId,
                Date = expenseDto.Date

            };
        _context
        

    }
}
