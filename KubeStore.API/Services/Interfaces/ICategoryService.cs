using KubeStore.API.Models;
using KubeStore.API.Services.Communication;

namespace KubeStore.API.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<Response<Category>> CreateCategory(Category category);

		public Task<Response<Category>> UpdateCategory(Category category);

		public Task<IEnumerable<Category>> GetParentCategories();

        public Task<IEnumerable<Category>> GetAllSubCategories(Guid id);

		public Task<IEnumerable<Category>> GetAllCategories();

		public Task<Response<Category>> GetCategoryById(Guid id);

		public Task<Response<Category>> GetCategoryByName(string name);
	}
}
