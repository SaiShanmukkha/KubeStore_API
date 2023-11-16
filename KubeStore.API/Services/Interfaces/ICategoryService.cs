using KubeStore.API.Models;

namespace KubeStore.API.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetParentCategories();

        //public Task<List<Category>> GetAllCategories(Category category);

        //public Task<Category> GetCategoryById(int id);

        //public Task<Category> GetCategoryByName(string name);

        public Category CreateCategory(Category category);

    }
}
