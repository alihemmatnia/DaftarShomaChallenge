namespace DaftarShomaChallenge.Application.DTOs.Order
{
	public record CreateOrderDto
	{
		public List<OrderLineDto> OrderLines { get; set; }
	}
}
