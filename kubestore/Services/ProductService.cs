using kubestore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace kubestore.Services
{
	public class ProductService : IKubeProductService
	{
		public ProductService() { }

		public IActionResult GetProduct(string productId)
		{
			throw new NotImplementedException();
		}

		public IActionResult GetProducts()
		{
			throw new NotImplementedException();
		}
	}
}
