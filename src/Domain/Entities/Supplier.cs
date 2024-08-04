namespace InventoryService.Domain.Entities;

public sealed record Supplier : Entity
{
	public required string Name { get; set; }
	public required string Street { get; set; }
	public required string City { get; set; }
	public string? State { get; set; }
	public required string PostalCode { get; set; }
	public required string Country { get; set; }
	public string? Phone { get; set; }
	public string? Email { get; set; }
	public ICollection<Product>? Products { get; set; }
}
