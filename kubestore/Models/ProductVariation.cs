namespace kubestore.Models
{
    public class ProductVariation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Product Product { get; set; }
    }
}
