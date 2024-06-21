namespace DaftarShomaChallenge.Application.DTOs.Product
{
	public record CreateProductDto
	{
		public string Title { get; set; }
		public int Price { get; set; }
	}
}
