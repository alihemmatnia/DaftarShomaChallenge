using DaftarShomaChallenge.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaftarShomaChallenge.Infrastructure.Data.Configuration
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure (EntityTypeBuilder<Product> builder)
		{
			builder.HasMany(x => x.OrderLines).WithOne(x => x.Product)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
