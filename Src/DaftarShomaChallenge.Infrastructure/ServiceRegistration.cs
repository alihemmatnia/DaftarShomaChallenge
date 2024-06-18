using DaftarShomaChallenge.Common.Configuration;
using DaftarShomaChallenge.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DaftarShomaChallenge.Infrastructure
{

	public static class ServiceRegistration
	{
		public static IServiceCollection AddInfrastructureService (this IServiceCollection services)
		{
			#region Repositories

			#endregion

			services.AddDbContext<DaftarShomaDbContext>(opt =>
			{
				opt.UseSqlServer(DbContextConfiguration.Config.ConnectionString);
			});

			return services;
		}

	}
}