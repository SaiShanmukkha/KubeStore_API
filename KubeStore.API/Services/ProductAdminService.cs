using KubeStore.API.Data;
using KubeStore.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KubeStore.API.Services
{
	public class ProductAdminService : IProductAdminService
	{
		private readonly ApplicationDBContext _dbContext;
		public ProductAdminService(ApplicationDBContext dBContext) 
		{ 
			_dbContext = dBContext;
		}

		public IActionResult AddProduct()
		{
			throw new NotImplementedException();
		}

		public IActionResult DeleteProduct()
		{
			throw new NotImplementedException();
		}

		public IActionResult UpdateProduct()
		{
			throw new NotImplementedException();
		}
	}
}
