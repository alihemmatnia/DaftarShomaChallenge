using AutoMapper;
using DaftarShomaChallenge.Application.DTOs.Order;
using DaftarShomaChallenge.Core.Domain.Entities;

namespace DaftarShomaChallenge.Application.Mapper
{
	public class OrderMapperProfile : Profile
	{
		public OrderMapperProfile ()
		{
			CreateMap<CreateOrderDto, Order>()
				.ConstructUsing(src=>new Order())
				.ForMember(src=>src.OrderLines, opt=>opt.Ignore())
				.ReverseMap();
		}
	}
}
