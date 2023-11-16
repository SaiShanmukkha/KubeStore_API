using KubeStore.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace KubeStore.API.Services.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetProducts();
        public Task<Product> GetProduct(string productId);
    }
}
