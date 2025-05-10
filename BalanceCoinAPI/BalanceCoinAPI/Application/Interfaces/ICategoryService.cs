using BalanceCoinAPI.DTOs;

namespace BalanceCoinAPI.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllCategoriesAsync();
        Task<CategoryDTO> GetCategoryByIdAsync(int id);
        Task<CategoryDTO> CreateCategoryAsync(CategoryDTO categoryDTO);
        Task<bool> DeleteCategoryAsync(int id);
        Task<CategoryDTO>UpdateCategoryAsync(int id,CategoryDTO categoryDTO);

    }
}
