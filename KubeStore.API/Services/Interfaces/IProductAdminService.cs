using Microsoft.AspNetCore.Mvc;

namespace KubeStore.API.Services.Interfaces
{
    public interface IProductAdminService
    {
        public IActionResult AddProduct();
        public IActionResult DeleteProduct();
        public IActionResult UpdateProduct();
    }
}
