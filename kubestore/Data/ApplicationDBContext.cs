using kubestore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace kubestore.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public virtual DbSet<Product> Products { get; set; }

    }
}
