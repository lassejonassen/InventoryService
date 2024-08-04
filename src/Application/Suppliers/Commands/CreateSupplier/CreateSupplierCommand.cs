using InventoryService.Application.Abstractions.Messaging;

namespace InventoryService.Application.Suppliers.Commands.CreateSupplier;

public sealed record CreateSupplierCommand(
	string Name,
	string Street,
	string City,
	string? State,
	string PostalCode,
	string Country,
	string? Phone,
	string? Email) : ICommand<Guid>;
