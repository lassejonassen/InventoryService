using InventoryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Infrastructure.Persistence;

public sealed class ApplicationDbContext : DbContext
{
	public DbSet<StorageLocation> StorageLocations => Set<StorageLocation>();
	public DbSet<ItemType> ItemTypes => Set<ItemType>();

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder) { }
}
