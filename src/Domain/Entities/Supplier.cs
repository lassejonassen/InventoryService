namespace InventoryService.Domain.Entities;

public sealed record Supplier
{
	public required string Name { get; set; }
	public required SupplierContactInfo ContactInfo { get; set; }
}

public sealed record SupplierContactInfo
{
	public required string Street { get; set; }
	public required string City { get; set; }
	public required string State { get; set; }
	public required string PostalCode { get; set; }
	public required string Country { get; set; }
	public required string Phone { get; set; }
	public required string Email { get; set; }
}
