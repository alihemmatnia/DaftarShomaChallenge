using DaftarShomaChallenge.Common.Models;
using DaftarShomaChallenge.Core.Domain.Entities;

namespace DaftarShomaChallenge.Core.Repositories.Interfaces
{
	public interface IProductRepository
	{
		Task<bool> CreateProduct (Product product, CancellationToken cancellationToken);
		Task<bool> RemoveProduct (Product product, CancellationToken cancellationToken);
		Task UpdateProduct (Product product);
		Task<Product> GetOne (int productId, CancellationToken cancellationToken);
		Task<List<Product>> GetAll (List<int> productIds, CancellationToken cancellationToken);
		Task<PageableResponse<Product>> GetPageable(Pageable pageable, CancellationToken cancellationToken);
		Task<Product> GetOneWithInclude (int productId, CancellationToken cancellationToken);
	}
}
