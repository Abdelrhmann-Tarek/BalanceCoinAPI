using BalanceCoinAPI.DTOs;

namespace BalanceCoinAPI.Application.Services
{
    public interface IExpenseService
    {
        Task<ExpenseDTO> CreateExpenseAsync(ExpenseDTO expenseDto);//Create a new expense/income entry

        Task<List<ExpenseDTO>> GetAllExpensesAsync();//Retrieve a list of all expenses/incomes.

        Task<ExpenseDTO?> GetExpenseByIdAsync(int id); //Retrieve details of a specific expense/income by ID.
        Task<List<ExpenseDTO>> GetExpenseByCategoryAsync(int categoryId); //Filter expenses/income by category

        Task<ExpenseDTO?> UpdateExpenseAsync(int id,ExpenseDTO expenseDto);//Update an existing expense/income entry.

        Task<bool> DeleteExpenseAsync(int id);//Delete an expense/income entry.
    }
}
