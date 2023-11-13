using kubestore.Models;
using Microsoft.AspNetCore.Mvc;

namespace kubestore.Services.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetProducts();
        public Task<Product> GetProduct(string productId);
    }
}
