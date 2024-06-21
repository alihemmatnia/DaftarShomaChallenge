using DaftarShomaChallenge.Core.Domain.Entities;

namespace DaftarShomaChallenge.Core.Repositories.Interfaces
{
	public interface IOrderRepository
	{
		Task<bool> CreateOrder (Order order, CancellationToken cancellationToken);
		Task<bool> CheckOrderNumber (string orderNumber, CancellationToken cancellationToken);
	}
}
