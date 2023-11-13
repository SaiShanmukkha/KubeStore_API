using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace kubestore.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {
		private readonly IConfiguration _configuration;
		private readonly String? _baseURL;
		public IndexModel(IConfiguration configuration)
		{
			_configuration = configuration;
			_baseURL = _configuration["App:URL"];
		}

		public void OnGet()
        {
			
        }
    }
}
