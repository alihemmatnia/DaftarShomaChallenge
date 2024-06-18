using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace DaftarShomaChallenge.Common.Configuration
{
	public class DbContextConfiguration
	{
		public const string SECTION_NAME = "DbContext";

		public string ConnectionString { get; set; }
		public static DbContextConfiguration Config { get; set; }

		public static DbContextConfiguration FromConfiguration (IConfiguration configuration)
		{
			IConfigurationSection section;
			try
			{
				section = configuration.GetRequiredSection(SECTION_NAME);
			}
			catch (InvalidOperationException)
			{
				throw new Exception(SECTION_NAME);
			}

			try
			{
				var config = new DbContextConfiguration();
				new ConfigureFromConfigurationOptions<DbContextConfiguration>(section)
				   .Configure(config);
				return config;
			}
			catch (Exception)
			{
				throw new Exception(SECTION_NAME);
			}
		}
	}
}
