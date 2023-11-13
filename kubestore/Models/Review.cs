using Microsoft.AspNetCore.Identity;

namespace kubestore.Models
{
    public class Review
    {
        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; } 

        public virtual string Description { get; set; }

        public virtual int Rating { get; set; }

        public virtual DateTime CreatedAt { get; set; }

        public virtual DateTime UpdatedAt { get; set; }

        public virtual Product Product { get; set; }

        public virtual IdentityUser? User { get; set; }

        public virtual bool IsVerifiedPurchase { get; set; }
    }
}
