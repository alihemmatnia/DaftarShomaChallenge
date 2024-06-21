using AutoMapper;
using DaftarShomaChallenge.Application.DTOs.Product;
using DaftarShomaChallenge.Application.Services.Interfaces;
using DaftarShomaChallenge.Common.DTOs;
using DaftarShomaChallenge.Common.Models;
using DaftarShomaChallenge.Core.Domain.Entities;
using DaftarShomaChallenge.Core.Repositories.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System.Net;

namespace DaftarShomaChallenge.Application.Services
{
	public class ProductApplicationService : IProductApplicationService
	{
		private readonly IProductRepository _productRepository;
		private IValidator<CreateProductDto> _productvalidator;
		private readonly IMapper _mapper;
		private readonly ILogger<ProductApplicationService> _logger;

		public ProductApplicationService (IProductRepository productRepository, IValidator<CreateProductDto> productvalidator, IMapper mapper, ILogger<ProductApplicationService> logger)
		{
			_productRepository = productRepository;
			_productvalidator = productvalidator;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<ApiResponseWithListError> CreateProduct (CreateProductDto dto, CancellationToken cancellationToken)
		{
			var validationResult = _productvalidator.Validate(dto);
			if (!validationResult.IsValid)
			{
				_logger.LogError("[CreateProduct] failed validation product");
				return new ApiResponseWithListError()
				{
					ErrorMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList(),
					Sucess = false,
					StatusCode = HttpStatusCode.BadRequest
				};
			}


			var product = _mapper.Map<Product>(dto);

			var result = await _productRepository.CreateProduct(product, cancellationToken);
			if (result)
			{
				_logger.LogInformation("[CreateProduct] create product with title:{title}, successfully", product.Title);
				return new ApiResponseWithListError()
				{
					Sucess = true,
					Message = "محصول جدید با موفقیت ثبت شد",
					StatusCode = HttpStatusCode.Created
				};
			}

			_logger.LogError("[CreateProduct] failed create product");
			return new ApiResponseWithListError()
			{
				Sucess = false,
				Message = "مشکل در ثبت محصول وجود دارد",
				StatusCode = HttpStatusCode.InternalServerError
			};
		}

		public async Task<ApiResponse> RemoveProduct (int productId, CancellationToken cancellationToken)
		{
			var product = await _productRepository.GetOne(productId, cancellationToken);
			if (product == null)
			{
				_logger.LogError("[RemoveProduct] product {productId} not found", productId);
				return new ApiResponse()
				{
					Sucess = false,
					Message = "محصول موردنظر وجود ندارد",
					StatusCode = HttpStatusCode.NotFound
				};
			}

			var result = await _productRepository.RemoveProduct(product, cancellationToken);
			if (result)
			{
				_logger.LogInformation("[RemoveProduct] remove product {productId}, successfully", productId);
				return new ApiResponse()
				{
					Sucess = true,
					Message = "محصول با موفقیت حذف شد",
					StatusCode = HttpStatusCode.OK
				};
			}

			_logger.LogError("[RemoveProduct] failed remove product");

			return new ApiResponse()
			{
				Sucess = false,
				Message = "مشکل در حذف محصول وجود دارد",
				StatusCode = HttpStatusCode.InternalServerError
			};
		}

		public async Task<PageableResponse<ProductDto>> GetProductPageable (Pageable pageable, CancellationToken cancellationToken)
		{
			var productPageable = await _productRepository.GetPageable(pageable, cancellationToken);
			var products = _mapper.Map<List<ProductDto>>(productPageable.Values);

			return new PageableResponse<ProductDto>(products, productPageable.Count);
		}
	}
}
