using Microsoft.AspNetCore.Mvc;

namespace kubestore.Services.Interfaces
{
    public interface IKubeProductService
    {
        public IActionResult GetProducts();
        public IActionResult GetProduct(string productId);
    }
}
