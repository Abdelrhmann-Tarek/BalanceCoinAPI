using BalanceCoinAPI.DTOs;

namespace BalanceCoinAPI.Application.Services
{
    public interface IIncomeService
    {
        Task<IncomeDTO> CreateIncomeAsync(IncomeDTO incomeDto);//Create a new expense/income entry

        Task<List<IncomeDTO>> GetAllIncomesAsync();//Retrieve a list of all expenses/incomes.

        Task<IncomeDTO?> GetIncomeByIdAsync(int id); //Retrieve details of a specific expense/income by ID.
        Task<List<IncomeDTO>> GetIncomesByCategoryAsync(int categoryId); //Filter expenses/income by category

        Task<IncomeDTO?> UpdateIncomeAsync(int id, IncomeDTO incomeDto);//Update an existing expense/income entry.

        Task<bool> DeleteIncomeAsync(int id);//Delete an expense/income entry.

    }
}

