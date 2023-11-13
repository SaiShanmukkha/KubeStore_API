using kubestore.Models;

namespace kubestore.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetParentCategories();

        //public Task<List<Category>> GetAllCategories(Category category);

        //public Task<Category> GetCategoryById(int id);

        //public Task<Category> GetCategoryByName(string name);

        public Task<Category> CreateCategory(Category category);

    }
}
