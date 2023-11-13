using Microsoft.AspNetCore.Mvc;

namespace kubestore.Services.Interfaces
{
    public interface IProductAdminService
    {
        public IActionResult AddProduct();
        public IActionResult DeleteProduct();
        public IActionResult UpdateProduct();
    }
}
