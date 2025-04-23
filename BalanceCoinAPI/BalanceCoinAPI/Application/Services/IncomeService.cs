using BalanceCoinAPI.Application.Services;
using BalanceCoinAPI.DTOs;
using BalanceCoinAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace BalanceCoinAPI.Application.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly ApplicationDBContext _context;

        public IncomeService(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<IncomeDTO> CreateIncomeAsync(IncomeDTO incomeDto)
        {
            var income = new Income
            {
                Title= incomeDto.Title,
                Amount = incomeDto.Amount,
                CategoryId = incomeDto.CategoryId,
                Date = incomeDto.Date
            };
            _context.Incomes.Add(income);
            await _context.SaveChangesAsync();
            incomeDto.Id = income.Id;
            return incomeDto;
        }
        public async Task<List<IncomeDTO>> GetAllIncomesAsync()           //Retrieve a list of all expenses/incomes.
        {
            return await _context.Incomes.Select(i=>new IncomeDTO { 
                
                Title = i.Title, 
                Amount = i.Amount,
                CategoryId=i.CategoryId,
                Date=i.Date})
                
                .ToListAsync(); //Executes a query and returns the results as a List<T> (async)


                         /*var incomes = await _context.Incomes.ToListAsync();

                          return incomes.Select(i => new IncomeDTO
                           {
                             Id = i.Id,
                             Title = i.Title,
                             Amount = i.Amount,
                             CategoryId = i.CategoryId,
                             Date = i.Date
                                }).ToList();*/

        }
        public async Task<IncomeDTO> GetIncomeByIdAsync(int id)
        {
            var income = await _context.Incomes.FindAsync(id);

            if (income == null) return null;

            return new IncomeDTO
            {
                Title = income.Title,
                Amount = income.Amount,
                CategoryId = income.CategoryId,
                Date = income.Date

            };
        }

    }
}
