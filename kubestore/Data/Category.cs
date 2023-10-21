using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace kubestore.Data
{
	public class Category
	{
		[PrimaryKey]
		public long id {  get; set; }

		[Required]
		public string name { get; set; }
	}
}
