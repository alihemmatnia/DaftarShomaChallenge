using AutoMapper;
using DaftarShomaChallenge.Application.DTOs.Product;
using DaftarShomaChallenge.Application.Mapper;
using DaftarShomaChallenge.Application.Services;
using DaftarShomaChallenge.Application.Services.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DaftarShomaChallenge.Application
{
	public static class ServiceRegistration
	{
		public static IServiceCollection AddApplicationService (this IServiceCollection services)
		{
			services.AddScoped<IProductApplicationService, ProductApplicationService>();
			services.AddScoped<IOrderApplicationService, OrderApplicationService>();

			#region FluentValidation Config
			services.AddValidatorsFromAssemblyContaining<CreateProductDto>();
			#endregion

			#region Auto Mapper Config
			var profiles = typeof(ProductMapperProfile).Assembly.GetTypes()
				.Where(x => typeof(Profile).IsAssignableFrom(x));

			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfiles(profiles.Select(x => Activator.CreateInstance(x) as Profile));
			});

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);
			#endregion

			return services;
		}
	}
}