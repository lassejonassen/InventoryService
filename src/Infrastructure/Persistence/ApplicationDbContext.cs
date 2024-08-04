using InventoryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Infrastructure.Persistence;

public sealed class ApplicationDbContext : DbContext
{
	public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();
	public DbSet<StorageLocation> StorageLocations => Set<StorageLocation>();
	public DbSet<Product> Products => Set<Product>();
	public DbSet<ProductType> ProductTypes => Set<ProductType>();
	public DbSet<Supplier> Suppliers => Set<Supplier>();

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder) { 
		base.OnModelCreating(modelBuilder);

		var assembly = typeof(ApplicationDbContext).Assembly;
		modelBuilder.ApplyConfigurationsFromAssembly(assembly);
	}
}
