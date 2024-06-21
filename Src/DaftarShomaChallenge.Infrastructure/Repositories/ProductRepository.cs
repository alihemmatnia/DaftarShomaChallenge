using DaftarShomaChallenge.Common.Extensions;
using DaftarShomaChallenge.Common.Models;
using DaftarShomaChallenge.Core.Domain.Entities;
using DaftarShomaChallenge.Core.Repositories.Interfaces;
using DaftarShomaChallenge.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DaftarShomaChallenge.Infrastructure.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly DaftarShomaDbContext _context;

		public ProductRepository (DaftarShomaDbContext context)
		{
			_context = context;
		}

		public async Task<bool> CreateProduct (Product product, CancellationToken cancellationToken)
		{
			_context.Products.Add(product);
			return await _context.SaveChangesAsync(cancellationToken) > 0;
		}

		public Task<List<Product>> GetAll (List<int> productIds, CancellationToken cancellationToken)
		{
			return _context.Products.Where(p => productIds.Contains(p.Id))
				.ToListAsync(cancellationToken);
		}

		public Task<Product> GetOne (int productId, CancellationToken cancellationToken)
		{
			return _context.Products.FirstOrDefaultAsync(x => x.Id == productId, cancellationToken);
		}

		public Task<PageableResponse<Product>> GetPageable (Pageable pageable, CancellationToken cancellationToken)
		{
			return _context.Products.UsePageableAsync(pageable, cancellationToken);
		}

		public async Task<bool> RemoveProduct (Product product, CancellationToken cancellationToken)
		{
			_context.Products.Remove(product);
			return await _context.SaveChangesAsync(cancellationToken) > 0;
		}

		public Task UpdateProduct (Product product)
		{
			return Task.FromResult(_context.Products.Update(product));
		}
	}
}
