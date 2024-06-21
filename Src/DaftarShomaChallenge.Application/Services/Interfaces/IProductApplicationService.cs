using DaftarShomaChallenge.Application.DTOs.Product;
using DaftarShomaChallenge.Common.DTOs;
using DaftarShomaChallenge.Common.Models;

namespace DaftarShomaChallenge.Application.Services.Interfaces
{
	public interface IProductApplicationService
	{
		Task<ApiResponseWithListError> CreateProduct (CreateProductDto dto, CancellationToken cancellationToken);
		Task<ApiResponse> RemoveProduct (int productId, CancellationToken cancellationToken);
		Task<PageableResponse<ProductDto>> GetProductPageable (Pageable pageable, CancellationToken cancellationToken);
	}
}
