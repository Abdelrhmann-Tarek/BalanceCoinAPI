using BalanceCoinAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace BalanceCoinAPI.Application.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly ApplicationDBContext _context;

        public BalanceService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<decimal> GetBalanceAsync()
        {
            var totalIncome = await _context.Incomes.SumAsync(i => (decimal?)i.Amount) ?? 0;
            var totalExpense = await _context.Expenses.SumAsync(e => (decimal?)e.Amount) ?? 0;
            return totalIncome - totalExpense;
        }
    }
}

