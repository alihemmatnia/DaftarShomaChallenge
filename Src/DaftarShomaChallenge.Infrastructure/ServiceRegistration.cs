using DaftarShomaChallenge.Common.Configuration;
using DaftarShomaChallenge.Core.Repositories.Interfaces;
using DaftarShomaChallenge.Infrastructure.Data.Context;
using DaftarShomaChallenge.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DaftarShomaChallenge.Infrastructure
{
	public static class ServiceRegistration
	{
		public static IServiceCollection AddInfrastructureService (this IServiceCollection services)
		{
			#region Repositories
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
			services.AddScoped<IOrderLineRepository, OrderLineRepository>();
			#endregion

			services.AddDbContext<DaftarShomaDbContext>(opt =>
			{
				opt.UseSqlServer(DbContextConfiguration.Config.ConnectionString);
			});

			return services;
		}
	}
}