using DaftarShomaChallenge.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DaftarShomaChallenge.Infrastructure.Data.Context
{
	public class DaftarShomaDbContext : DbContext
	{
		public DaftarShomaDbContext (DbContextOptions<DaftarShomaDbContext> options) : base(options)
		{
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<OrderLine> OrderLines { get; set; }
		public DbSet<Order> Orders { get; set; }

		protected override void OnModelCreating (ModelBuilder modelBuilder)
		{
			Assembly assemblyWithConfigurations = GetType().Assembly;
			modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
		}
	}
}
