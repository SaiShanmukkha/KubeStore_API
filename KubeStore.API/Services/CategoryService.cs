using KubeStore.API.Data;
using KubeStore.API.Models;
using KubeStore.API.Services.Communication;
using KubeStore.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace KubeStore.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDBContext _dbContext;

        public CategoryService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Response<Category>> CreateCategory(Category category)
        {
            Response<Category> resp;
            try
            {
                category.Id = Guid.NewGuid();
                var entity = await _dbContext.Categories.AddAsync(category);
                await _dbContext.SaveChangesAsync();
                resp = new(category);
            }catch (Exception ex)
            {
                resp = new(ex.Message);
            }
            return resp;
        }

		public async Task<Response<Category>> UpdateCategory(Category category)
		{
			Response<Category> resp;
			try
			{
				if(await _dbContext.Categories.Where(x=>x.Id == category.Id).FirstOrDefaultAsync() != null)
				{
					_dbContext.Update(category);
					await _dbContext.SaveChangesAsync();
				}

				resp = new(category);
			}
			catch (Exception ex)
			{
				resp = new(ex.Message);
			}
			return resp;
		}

		public async Task<IEnumerable<Category>> GetParentCategories()
        {
            var parentCategories = await _dbContext.Categories.Where(x=>x.category == null).ToListAsync();
			if (parentCategories.IsNullOrEmpty())
			{
				return new List<Category>();
			}
			return parentCategories;
        }

		public async Task<IEnumerable<Category>> GetAllCategories()
		{
			var categories = await _dbContext.Categories.ToListAsync();
			if (categories.IsNullOrEmpty())
			{
				return new List<Category>();
			}
			return categories;
		}

        public async Task<IEnumerable<Category>> GetAllSubCategories(Guid id)
        {
            var subCategories = await _dbContext.Categories.Where(x=>x.category != null && x.category.Id == id).ToListAsync();
			if (subCategories.IsNullOrEmpty())
			{
				return new List<Category>();
			}
			return subCategories;
		}


		public async Task<Response<Category>> GetCategoryById(Guid id)
        {
			Response<Category> resp;
			try
			{
				var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
				if (category == null)
				{
					resp = new("Not Found");
				}
				else
				{
					resp = new(category);
				}
			}
			catch (Exception ex)
			{
				resp = new(ex.Message);
			}
			return resp;
		}

		public async Task<Response<Category>> GetCategoryByName(string name)
        {
			Response<Category> resp;
			try
			{
				var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Name == name);
				if (category == null)
				{
					resp = new("Not Found");
				}
				else
				{
					resp = new(category);
				}
			}
			catch (Exception ex)
			{
				resp = new (ex.Message);
			}
			return resp;
		}

	}
}
