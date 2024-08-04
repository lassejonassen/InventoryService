namespace InventoryService.Domain.Entities;

public sealed record ProductType : Entity
{
	public required string Name { get; set; }
	public ICollection<Product>? Products { get; set; }
}
