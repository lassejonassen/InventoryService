using InventoryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryService.Infrastructure.Persistence.EntityConfigurations;

public class InventoryItemConfiguration : IEntityTypeConfiguration<InventoryItem>
{
	public void Configure(EntityTypeBuilder<InventoryItem> builder)
	{
		builder.HasKey(x => x.Id);

		builder.HasOne(x => x.Product)
			.WithMany(x => x.Items)
			.HasForeignKey(x => x.ProductId);

		builder.HasOne(x => x.StorageLocation)
			.WithMany(x => x.Items)
			.HasForeignKey(x => x.StorageLocationId)
			.IsRequired();
	}
}
