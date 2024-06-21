using DaftarShomaChallenge.Core.Domain.Entities;
using DaftarShomaChallenge.Core.Repositories.Interfaces;
using DaftarShomaChallenge.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DaftarShomaChallenge.Infrastructure.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly DaftarShomaDbContext _context;

		public OrderRepository (DaftarShomaDbContext context)
		{
			_context = context;
		}

		public Task<bool> CheckOrderNumber (string orderNumber, CancellationToken cancellationToken)
		{
			return _context.Orders.AnyAsync(x => x.Number == orderNumber);
		}

		public async Task<bool> CreateOrder (Order order, CancellationToken cancellationToken)
		{
			_context.Orders.Add(order);
			return await _context.SaveChangesAsync(cancellationToken) > 0;
		}

	}
}
