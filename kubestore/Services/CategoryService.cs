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

        public async Task<List<Category>> GetAllCategories()
        {
            var categories = await _dbContext.Categories.ToListAsync();

            return categories;
        }

        public async Task<List<Category>> GetAllSubCategories(Guid id)
        {
            var subCategories = await _dbContext.Categories.Where(x=>x.category != null && x.category.Id == id).ToListAsync();

            return subCategories;
        }
    }
}
