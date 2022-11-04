using API.Models;
using API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly GPContext _context;
        public CategoryServices(GPContext context)
        {
            _context = context;

        }
        public async Task<int?> AddNewCategory(Category category)
        {
            var newCategory = _context.Categories.Add(category);

            if(newCategory == null) return null;

            await _context.SaveChangesAsync();

            return newCategory.Entity.Id;
        }

        public async Task<IEnumerable<Category>> GetAllCategorys()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            Category? category = await _context.Categories.FindAsync(id);

            return category;
        }

        public async Task<bool> RemoveCategory(int id)
        {
            Category? category = await _context.Categories.FindAsync(id);

            if(category == null) return false;

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();

            return true;
        }

        public Task<bool> UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}