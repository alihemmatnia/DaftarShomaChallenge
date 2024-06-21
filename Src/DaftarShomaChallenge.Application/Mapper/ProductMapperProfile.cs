using AutoMapper;
using DaftarShomaChallenge.Application.DTOs.Product;
using DaftarShomaChallenge.Core.Domain.Entities;

namespace DaftarShomaChallenge.Application.Mapper
{
	public class ProductMapperProfile : Profile
	{
		public ProductMapperProfile ()
		{
			CreateMap<CreateProductDto, Product>()
				.ConstructUsing(src => new Product(src.Title, src.Price))
				.ReverseMap();

			CreateMap<Product, ProductDto>()
				.ReverseMap();
		}
	}
}
