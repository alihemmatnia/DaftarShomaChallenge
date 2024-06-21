using DaftarShomaChallenge.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaftarShomaChallenge.Infrastructure.Data.Configuration
{
	public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
	{
		public void Configure (EntityTypeBuilder<OrderLine> builder)
		{
			
		}
	}
}
