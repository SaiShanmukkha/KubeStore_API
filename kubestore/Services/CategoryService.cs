using kubestore.Data;
using kubestore.Models;
using kubestore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace kubestore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDBContext _dbContext;

        public CategoryService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Category> CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetParentCategories()
        {
            var parentCategories = await _dbContext.Categories.Where(x=>x.category == null).ToListAsync();

            return parentCategories;
        }
    }
}
