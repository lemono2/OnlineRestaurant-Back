namespace OnlineShop.Dtos
{
	public class ProductDto
	{
		public int ProductId { get; set; }

		public string ProductName { get; set; } = null!;

		public decimal? ProductPrice { get; set; }

		public bool? HasNuts { get; set; }

		public string? ProductImage { get; set; }

		public bool? IsVegetarian { get; set; }

		public int? Spiciness { get; set; }

		public int? CategoryId { get; set; }
	}
}
