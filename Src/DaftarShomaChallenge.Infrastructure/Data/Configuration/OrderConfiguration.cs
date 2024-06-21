using DaftarShomaChallenge.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaftarShomaChallenge.Infrastructure.Data.Configuration
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure (EntityTypeBuilder<Order> builder)
		{
			builder.HasMany(x => x.OrderLines)
				.WithOne(x=>x.Order)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
