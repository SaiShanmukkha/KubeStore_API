using Microsoft.AspNetCore.Identity;

namespace kubestore.Data
{
	public class Review
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Rating { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public Product Product { get; set; }
		public IdentityUser? User{ get; set; }
		public bool IsVerifiedPurchase { get; set; }
	}
}
