using DaftarShomaChallenge.Common.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DaftarShomaChallenge.Common.Configuration.Extensions
{
    public static class DbContextConfigurationExtension
    {
        public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
        {
            DbContextConfiguration.Config = DbContextConfiguration.FromConfiguration(configuration);
            return services;
        }
    }
}
