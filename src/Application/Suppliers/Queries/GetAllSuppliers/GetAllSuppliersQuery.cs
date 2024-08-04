using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Entities;

namespace InventoryService.Application.Suppliers.Queries.GetAllSuppliers;

public sealed record GetAllSuppliersQuery : IQuery<IEnumerable<Supplier>>;