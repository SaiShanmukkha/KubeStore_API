namespace kubestore.Data
{
	public class ProductVariation
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public Product Product { get; set; }
	}
}
