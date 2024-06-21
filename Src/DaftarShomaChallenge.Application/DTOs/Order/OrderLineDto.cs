namespace DaftarShomaChallenge.Application.DTOs.Order
{
	public record OrderLineDto
	{
		public int ProductId { get; set; }
		public int Quantity { get; set; }
	}
}
