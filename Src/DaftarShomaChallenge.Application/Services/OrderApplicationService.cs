using AutoMapper;
using DaftarShomaChallenge.Application.DTOs.Order;
using DaftarShomaChallenge.Application.Services.Interfaces;
using DaftarShomaChallenge.Common.DTOs;
using DaftarShomaChallenge.Common.Generators;
using DaftarShomaChallenge.Core.Domain.Entities;
using DaftarShomaChallenge.Core.Repositories.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System.Net;

namespace DaftarShomaChallenge.Application.Services
{
	public class OrderApplicationService : IOrderApplicationService
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IOrderLineRepository _orderLineRepository;
		private readonly IProductRepository _productRepository;
		private IValidator<CreateOrderDto> _orderValidator;
		private IValidator<GetSalesBetweenDateDto> _saleValidator;
		private readonly IMapper _mapper;
		private readonly ILogger<OrderApplicationService> _logger;

		public OrderApplicationService (IOrderRepository orderRepository, IValidator<CreateOrderDto> orderValidator, IMapper mapper, IProductRepository productRepository, ILogger<OrderApplicationService> logger, IOrderLineRepository orderLineRepository, IValidator<GetSalesBetweenDateDto> saleValidator )
		{
			_orderRepository = orderRepository;
			_orderValidator = orderValidator;
			_mapper = mapper;
			_productRepository = productRepository;
			_logger = logger;
			_orderLineRepository = orderLineRepository;
			_saleValidator = saleValidator;
		}

		public async Task<ApiResponseWithListError> CreateOrder (CreateOrderDto dto, CancellationToken cancellationToken)
		{
			var validationResult = _orderValidator.Validate(dto);
			if (!validationResult.IsValid)
			{
				_logger.LogError("[CreateOrder] failed validation Order");
				return new ApiResponseWithListError()
				{
					ErrorMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList(),
					Sucess = false,
					StatusCode = HttpStatusCode.BadRequest
				};
			}

			#region orderNumber
			string orderNumber = OrderNumberGenerator.Generate();
			while (await _orderRepository.CheckOrderNumber(orderNumber, cancellationToken))
			{
				orderNumber = OrderNumberGenerator.Generate();
			}
			#endregion

			var order = _mapper.Map<Order>(dto);
			order.SetNumber(orderNumber);

			#region OrderLine
			var productIds = dto.OrderLines.Select(x => x.ProductId).ToList();
			var products = await _productRepository.GetAll(productIds, cancellationToken);

			foreach (var line in dto.OrderLines)
			{
				var product = products.FirstOrDefault(x => x.Id == line.ProductId);
				if (product == null)
				{
					_logger.LogError("[CreateOrder] product with id:{id} not found", line.ProductId);
					return new ApiResponseWithListError()
					{
						Sucess = false,
						StatusCode = HttpStatusCode.NotFound,
						ErrorMessages = [$"محصول {line.ProductId} پیدا نشد"]
					};
				}

				var orderLine = new OrderLine(product, line.Quantity);
				order.AddOrderLine(orderLine);
			}
			#endregion

			order.CalcTotalPrice();

			var result = await _orderRepository.CreateOrder(order, cancellationToken);
			if (result)
			{
				_logger.LogInformation("[CreateOrder] create order number:{number}, successfully", order.Number);
				return new ApiResponseWithListError()
				{
					Sucess = true,
					Message = "سفارش شما با موفقیت ثبت شد",
					StatusCode = HttpStatusCode.Created
				};
			}

			_logger.LogError("[CreateOrder] failed create order");
			return new ApiResponseWithListError()
			{
				Sucess = false,
				Message = "مشکل در ثبت سفارش وجود دارد",
				StatusCode = HttpStatusCode.InternalServerError
			};
		}

		public async Task<ApiResponse> GetWeeklySales (int productId, CancellationToken cancellationToken)
		{
			var product = await _productRepository.GetOne(productId, cancellationToken);
			if (product == null)
			{
				_logger.LogError("[GetWeeklySales] product with id:{id} not found", productId);
				return new ApiResponse()
				{
					Sucess = false,
					StatusCode = HttpStatusCode.NotFound,
					ErrorMessage = "محصول پیدا نشد"
				};
			}

			var startDate = DateTime.Now.AddDays(-7);
			var orderLine = await _orderLineRepository.GetOrderLine(productId, startDate, DateTime.Now);
			
			var saleCount = orderLine.Sum(x => x.Quantity);
			var saleTotalPrice = orderLine.Sum(x => x.Price);

			return new ApiResponse()
			{
				Message = $"در هفت روز گرشته محصول {product.Title} به تعداد {saleCount} و قیمت کل {saleTotalPrice} فروخته شده است",
				StatusCode = HttpStatusCode.OK,
				Sucess = true
			};
		}

		public async Task<ApiResponseWithListError> GetSalesBetweenDate (GetSalesBetweenDateDto dto)
		{
			var validationResult = _saleValidator.Validate(dto);
			if (!validationResult.IsValid)
			{
				_logger.LogError("[CreateOrder] failed validation Order");
				return new ApiResponseWithListError()
				{
					ErrorMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList(),
					Sucess = false,
					StatusCode = HttpStatusCode.BadRequest
				};
			}

			var salesCount = await _orderLineRepository.GetSalesCount(dto.StartDate, dto.EndDate);
			return new ApiResponseWithListError()
			{
				Message = $"در این بازه تعداد {salesCount} محصول فروخته شده است",
				StatusCode = HttpStatusCode.OK,
				Sucess = true
			};
		}
	}
}
