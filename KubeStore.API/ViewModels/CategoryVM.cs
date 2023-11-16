using KubeStore.API.Models;

namespace KubeStore.API.ViewModels
{
	public record CategoryVM
	{
		public required string Name { get; set; }

		public virtual Category? category { get; set; }
	}
}
