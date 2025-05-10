using BalanceCoinAPI.Application.Interfaces;
using BalanceCoinAPI.DTOs;
using BalanceCoinAPI.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using BalanceCoinAPI.Domain.Entities;
using Microsoft.Extensions.Logging;



namespace BalanceCoinAPI.Application.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<IncomeService> _logger;

        public IncomeService(ApplicationDBContext context, ILogger<IncomeService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IncomeDTO> CreateIncomeAsync(IncomeDTO incomeDto)
        {
            _logger.LogInformation("Adding Income:{Title}", incomeDto.Title);
            var income = new Income
            {
               
                Title= incomeDto.Title,
                Amount = incomeDto.Amount,
                CategoryId = incomeDto.CategoryId,
                Date = incomeDto.Date
            };
            _context.Incomes.Add(income);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Income created with ID: {Id}", income.Id);

            return new IncomeDTO
            {
                Id = income.Id,                  //  generated after SaveChangesAsync()
                Title = income.Title,
                Amount = income.Amount,
                CategoryId = income.CategoryId,
                Date = income.Date
            };
        }
        public async Task<List<IncomeDTO>> GetAllIncomesAsync()           //Retrieve a list of all expenses/incomes.
        {
            return await _context.Incomes.Select(i=>new IncomeDTO { 
                Id = i.Id,
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
        public async Task<IncomeDTO?> GetIncomeByIdAsync( int id)
        {
            var income = await _context.Incomes.FindAsync(id);

            if (income == null) return null;

            return new IncomeDTO
            {
                Id = income.Id,
                Title = income.Title,
                Amount = income.Amount,
                CategoryId = income.CategoryId,
                Date = income.Date

            };

        }

          public async Task<List<IncomeDTO>> GetIncomesByCategoryAsync(int categoryId)
                {
            var incomes = await _context.Incomes
                .Where(i => i.CategoryId == categoryId)
                .Select(e => new IncomeDTO
                {
                    Id = e.Id,
                    Amount = e.Amount,
                    Title = e.Title,
                    CategoryId = e.CategoryId,
                    Date = e.Date
                })
                .ToListAsync();

            return incomes;
              }
        public async Task<IncomeDTO?> UpdateIncomeAsync(int id, IncomeDTO incomeDto)
        {
            var income = await _context.Incomes.FindAsync(id);
            if (income == null) return null;
            income.Title = incomeDto.Title;
            income.Date=incomeDto.Date;
            income.CategoryId=incomeDto.CategoryId;
            income.Amount=incomeDto.Amount;
            await _context.SaveChangesAsync();
            return new IncomeDTO
            {
                Id = income.Id,
                Title = income.Title,
                Amount = income.Amount,
                CategoryId = income.CategoryId,
                Date = income.Date
            };





        }
        public async Task<bool> DeleteIncomeAsync(int id)
        {
            var income = await _context.Incomes.FindAsync(id);
            if(income==null)return false;
            _context.Incomes.Remove(income);
            await _context.SaveChangesAsync();
            return true;


        }

    }
}
