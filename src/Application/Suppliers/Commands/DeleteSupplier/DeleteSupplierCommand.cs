using InventoryService.Application.Abstractions.Messaging;

namespace InventoryService.Application.Suppliers.Commands.DeleteSupplier;

public sealed record DeleteSupplierCommand(Guid Id) : ICommand;