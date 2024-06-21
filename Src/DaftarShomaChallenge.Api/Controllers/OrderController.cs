using DaftarShomaChallenge.Application.DTOs.Order;
using DaftarShomaChallenge.Application.Services.Interfaces;
using DaftarShomaChallenge.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DaftarShomaChallenge.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderApplicationService _orderApplicationService;

		public OrderController (IOrderApplicationService orderApplicationService)
		{
			_orderApplicationService = orderApplicationService;
		}

		[HttpPost]
		public async Task<ApiResponseWithListError> Post (CreateOrderDto dto, CancellationToken cancellationToken)
		{
			return await _orderApplicationService.CreateOrder(dto, cancellationToken);
		}
	}
}
