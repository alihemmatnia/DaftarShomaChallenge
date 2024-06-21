using DaftarShomaChallenge.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace DaftarShomaChallenge.Common.Extensions
{
	public static class QueryableExtensions
	{
		public static async Task<PageableResponse<TEntity>> UsePageableAsync<TEntity> (
		  this IQueryable<TEntity> query,
		  Pageable pageable,
		  CancellationToken cancellationToken = default)
		  where TEntity : class
		{
			return new PageableResponse<TEntity>(await query
				.Skip((pageable.Page - 1) * pageable.Limit)
				.Take(pageable.Limit)
				.AsNoTracking()
				.ToListAsync(cancellationToken), await query.LongCountAsync(cancellationToken));
		}
	}
}
