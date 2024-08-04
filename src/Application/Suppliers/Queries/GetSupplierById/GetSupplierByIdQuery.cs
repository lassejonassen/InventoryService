using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Entities;

namespace InventoryService.Application.Suppliers.Queries.GetSupplierById;

public sealed record GetSupplierByIdQuery(Guid Id) : IQuery<Supplier>;