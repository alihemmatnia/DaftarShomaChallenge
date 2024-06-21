using DaftarShomaChallenge.Core.Domain.Entities;

namespace DaftarShomaChallenge.Core.Repositories.Interfaces
{
	public interface IOrderLineRepository
	{
		Task<bool> AddOrderLines (List<OrderLine> orderLines, CancellationToken cancellationToken);
	}
}
