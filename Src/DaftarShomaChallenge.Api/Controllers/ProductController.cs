using DaftarShomaChallenge.Application.DTOs.Product;
using DaftarShomaChallenge.Application.Services.Interfaces;
using DaftarShomaChallenge.Common.DTOs;
using DaftarShomaChallenge.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace DaftarShomaChallenge.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductApplicationService _productApplicationService;

		public ProductController (IProductApplicationService productApplicationService)
		{
			_productApplicationService = productApplicationService;
		}

		[HttpPost]
		public async Task<ApiResponseWithListError> Post (CreateProductDto dto, CancellationToken cancellationToken)
		{
			return await _productApplicationService.CreateProduct(dto, cancellationToken);
		}

		[HttpGet("GetAll")]
		public async Task<PageableResponse<ProductDto>> GetAll ([FromQuery]Pageable pageable,CancellationToken cancellationToken)
		{
			return await _productApplicationService.GetProductPageable(pageable, cancellationToken);
		}

		[HttpDelete]
		public async Task<ApiResponse> RemoveProduct([FromQuery]int productId, CancellationToken cancellationToken)
		{
			return await _productApplicationService.RemoveProduct(productId, cancellationToken);
		}
	}
}
