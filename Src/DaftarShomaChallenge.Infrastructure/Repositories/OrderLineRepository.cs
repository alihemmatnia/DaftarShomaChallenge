using DaftarShomaChallenge.Core.Domain.Entities;
using DaftarShomaChallenge.Core.Repositories.Interfaces;
using DaftarShomaChallenge.Infrastructure.Data.Context;

namespace DaftarShomaChallenge.Infrastructure.Repositories
{
	public class OrderLineRepository : IOrderLineRepository
	{
		private readonly DaftarShomaDbContext _context;
		public OrderLineRepository (DaftarShomaDbContext context)
		{
			_context = context;
		}

		public async Task<bool> AddOrderLines (List<OrderLine> orderLines, CancellationToken cancellationToken)
		{
			_context.OrderLines.AddRange(orderLines);
			return await _context.SaveChangesAsync(cancellationToken) > 0;
		}
	}
}
