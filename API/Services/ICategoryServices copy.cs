using API.Models;

namespace API.Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetAllCategorys();
        Task<bool> UpdateCategory(Category category);
        Task<Category?> GetCategoryById(int id);
        Task<int?> AddNewCategory(Category category);
        Task<bool> RemoveCategory(int id);
    }
}