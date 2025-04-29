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
        public async Task<ExpenseDTO> CreateExpenseAsync(ExpenseDTO expenseDto)
        {
            var expense = new Expense
            {
                Title = expenseDto.Title,
                Amount = expenseDto.Amount,
                CategoryId = expenseDto.CategoryId,
                Date = expenseDto.Date

            };
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
            expenseDto.Id = expense.Id;
            return expenseDto;
        }
        public async Task<List<ExpenseDTO>> GetAllExpensesAsync()
        {
            return await _context.Expenses.Select(e => new ExpenseDTO
            {

                Id = e.Id,
                Amount = e.Amount,
                Title = e.Title,
                CategoryId = e.CategoryId,
                Date = e.Date
            }).ToListAsync();
        }
        public async Task<ExpenseDTO?> GetExpenseByIdAsync(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null) return null;

            return new ExpenseDTO
            {

                Id = expense.Id,
                Title = expense.Title,
                Amount = expense.Amount,
                CategoryId = expense.CategoryId,
                Date = expense.Date

            };
        }
        public async Task<List<ExpenseDTO>> GetExpenseByCategoryIdAsync(int categoryId)
        {
            var expenses = await _context.Expenses
                .Where(i => i.CategoryId == categoryId)
                .Select(e => new ExpenseDTO
                {
                    Id = e.Id,
                    Amount = e.Amount,
                    Title = e.Title,
                    CategoryId = e.CategoryId,
                    Date = e.Date
                })
                .ToListAsync();

            return expenses;
        }

        public async Task<ExpenseDTO?> UpdateExpenseAsync(int id, ExpenseDTO expenseDto)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null) return null;
            expense.Title = expenseDto.Title;
            expense.Amount = expenseDto.Amount;
            expense.CategoryId = expenseDto.CategoryId;
            expense.Date = expenseDto.Date;
            await _context.SaveChangesAsync();
            return new ExpenseDTO
            {

                Id = expense.Id,
                Title = expense.Title,
                Amount = expense.Amount,
                CategoryId = expense.CategoryId,
                Date = expense.Date

            };

        }

        public async Task<bool> DeleteExpenseAsync(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null) return false;
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
            return true;

        }




    }
}
