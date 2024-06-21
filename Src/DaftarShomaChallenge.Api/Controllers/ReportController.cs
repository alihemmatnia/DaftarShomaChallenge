using DaftarShomaChallenge.Application.DTOs.Order;
using DaftarShomaChallenge.Application.Services.Interfaces;
using DaftarShomaChallenge.Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DaftarShomaChallenge.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReportController : ControllerBase
	{
		private readonly IOrderApplicationService _orderApplicationService;

		public ReportController (IOrderApplicationService orderApplicationService)
		{
			_orderApplicationService = orderApplicationService;
		}

		[HttpGet("WeeklySale")]
		public async Task<ApiResponse> GetWeeklySale (int productId, CancellationToken cancellationToken)
		{
			return await _orderApplicationService.GetWeeklySales(productId, cancellationToken);
		}

		[HttpGet("SaleBetWeen")]
		public async Task<ApiResponseWithListError> GetSaleBetWeen ([FromQuery] GetSalesBetweenDateDto dto, CancellationToken cancellationToken)
		{
			return await _orderApplicationService.GetSalesBetweenDate(dto);
		}
	}
}
