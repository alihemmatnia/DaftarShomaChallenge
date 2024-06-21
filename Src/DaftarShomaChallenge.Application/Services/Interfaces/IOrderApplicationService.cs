using DaftarShomaChallenge.Application.DTOs.Order;
using DaftarShomaChallenge.Common.DTOs;

namespace DaftarShomaChallenge.Application.Services.Interfaces
{
	public interface IOrderApplicationService
	{
		Task<ApiResponseWithListError> CreateOrder (CreateOrderDto dto, CancellationToken cancellationToken);
		Task<ApiResponseWithListError> GetSalesBetweenDate (GetSalesBetweenDateDto dto);
		Task<ApiResponse> GetWeeklySales (int productId, CancellationToken cancellationToken);
	}
}
