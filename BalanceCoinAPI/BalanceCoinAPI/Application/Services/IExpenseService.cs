using BalanceCoinAPI.DTOs;

namespace BalanceCoinAPI.Application.Services
{
    public interface IExpenseService
    {
        Task<ExpenceDTO> CreateExpenseAsync(ExpenceDTO expenseDto);//Create a new expense/income entry

        Task<List<ExpenceDTO>> GetAllExpensesAsync();//Retrieve a list of all expenses/incomes.

        Task<ExpenceDTO?> GetExpenseByIdAsync(int id); //Retrieve details of a specific expense/income by ID.
        Task<List<ExpenceDTO>> GetExpenseByCategoryAsync(int categoryId); //Filter expenses/income by category

        Task<ExpenceDTO?> UpdateExpenseAsync(int id,ExpenceDTO incomeDto);//Update an existing expense/income entry.

        Task<bool> DeleteExpenseAsync(int id);//Delete an expense/income entry.
    }
}
