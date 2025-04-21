using BalanceCoinAPI.DTOs;

namespace BalanceCoinAPI.Application.Services
{
    public interface IIncomeService
    {
        Task<List<IncomeDTO>> GetAllIncomesAsync();
        Task<IncomeDTO> GetIncomeByIdAsync(int id);
        Task<List<IncomeDTO>> GetIncomesByCategoryAsync(int categoryId); 
        Task<IncomeDTO> CreateIncomeAsync(IncomeDTO incomeDto);
        Task<IncomeDTO> UpdateIncomeAsync(int id, IncomeDTO incomeDto);
        Task<bool> DeleteIncomeAsync(int id);
    }
}

