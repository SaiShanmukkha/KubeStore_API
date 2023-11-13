namespace kubestore.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual Category? category { get; set; }
    }
}
