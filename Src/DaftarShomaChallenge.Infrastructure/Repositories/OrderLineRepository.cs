using DaftarShomaChallenge.Core.Domain.Entities;
using DaftarShomaChallenge.Core.Repositories.Interfaces;
using DaftarShomaChallenge.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DaftarShomaChallenge.Infrastructure.Repositories
{
	public class OrderLineRepository : IOrderLineRepository
	{
		private readonly DaftarShomaDbContext _context;
		public OrderLineRepository (DaftarShomaDbContext context)
		{
			_context = context;
		}

		public Task<List<OrderLine>> GetOrderLine (int productId, DateTime startDate, DateTime endDate)
		{
			return _context.OrderLines
				.AsNoTracking()
				.Include(x => x.Order)
				.Include(x => x.Product)
				.Where(o => (o.Order.Date >= startDate && o.Order.Date <= endDate)
									&& o.Product.Id == productId)
				.ToListAsync();
		}

		public Task<int> GetSalesCount (DateTime startDate, DateTime endDate)
		{
			return _context.OrderLines
				.AsNoTracking()
				.Include(x => x.Order)
				.Include(x => x.Product)
				.Where(o => o.Order.Date >= startDate && o.Order.Date <= endDate)
				.SumAsync(x => x.Quantity);
		}
	}
}
