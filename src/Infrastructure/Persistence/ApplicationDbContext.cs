using InventoryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Infrastructure.Persistence;

public sealed class ApplicationDbContext : DbContext
{
	public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();
	public DbSet<StorageLocation> StorageLocations => Set<StorageLocation>();

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder) { 
		base.OnModelCreating(modelBuilder);

		var assembly = typeof(ApplicationDbContext).Assembly;
		modelBuilder.ApplyConfigurationsFromAssembly(assembly);
	}
}
