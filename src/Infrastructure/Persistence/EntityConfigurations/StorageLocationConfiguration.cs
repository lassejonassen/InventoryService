using InventoryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryService.Infrastructure.Persistence.EntityConfigurations;

public class StorageLocationConfiguration : IEntityTypeConfiguration<StorageLocation>
{
	public void Configure(EntityTypeBuilder<StorageLocation> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Name)
			.HasMaxLength(255)
			.IsRequired();

		builder.HasMany(x => x.Items)
			.WithOne(x => x.StorageLocation)
			.HasForeignKey(x => x.StorageLocationId!)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
