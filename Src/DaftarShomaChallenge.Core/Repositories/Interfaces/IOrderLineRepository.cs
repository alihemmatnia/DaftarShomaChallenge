using DaftarShomaChallenge.Core.Domain.Entities;

namespace DaftarShomaChallenge.Core.Repositories.Interfaces
{
	public interface IOrderLineRepository
	{
		Task<int> GetSalesCount (DateTime startDate, DateTime endDate);
		Task<List<OrderLine>> GetOrderLine (int productId, DateTime startDate, DateTime endDate);
	}
}
