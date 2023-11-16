using KubeStore.API.Data;
using KubeStore.API.Models;
using KubeStore.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KubeStore.API.Services
{
	public class ProductService : IProductService
	{
		private readonly ApplicationDBContext _dbContext;
		public ProductService(ApplicationDBContext dbContext) 
		{
			_dbContext = dbContext;
		}

		public Task<Product> GetProduct(string productId)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Product>> GetProducts()
		{
			if (_dbContext.Products != null)
			{
				var productList = await _dbContext.Products.ToListAsync();
				return productList;
			}
			return new List<Product>();
		}
	}
}
