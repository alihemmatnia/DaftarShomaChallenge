using AutoMapper;
using DaftarShomaChallenge.Application.DTOs.Order;
using DaftarShomaChallenge.Core.Domain.Entities;

namespace DaftarShomaChallenge.Application.Mapper
{
	public class OrderLineMapperProfile : Profile
	{
		public OrderLineMapperProfile ()
		{
			CreateMap<OrderLineDto, OrderLine>()
				.ReverseMap();
		}
	}
}
