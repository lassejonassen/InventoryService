using InventoryService.Domain.Entities;
using InventoryService.Domain.Shared;

namespace InventoryService.Domain.Repositories;

public interface ISupplierRepository
{
	Task<Result> AddAsync(Supplier supplier, CancellationToken cancellationToken);
	Task<Result<IEnumerable<Supplier>>> GetAllAsync(CancellationToken cancellationToken);
	Task<Result<Supplier>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
	Task<Result<Supplier>> GetByNameAsync(string name, CancellationToken cancellationToken);
	Task<Result> UpdateAsync(Supplier supplier, CancellationToken cancellationToken);
	Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken);
}
