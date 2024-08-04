using InventoryService.Domain.Entities;
using InventoryService.Domain.Shared;

namespace InventoryService.Domain.Repositories;

public interface IInventoryItemRepository
{
	Task<Result> CreateAsync(InventoryItem item, CancellationToken cancellationToken);
	Task<Result<IEnumerable<InventoryItem>>> GetAllAsync(CancellationToken cancellationToken);
	Task<Result<InventoryItem>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
	Task<Result<InventoryItem>> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken);
	Task<Result<IEnumerable<InventoryItem>>> GetByStorageLocationIdAsync(Guid storageLocationId, CancellationToken cancellationToken);
	Task<Result> UpdateAsync(InventoryItem item, CancellationToken cancellationToken);
	Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken);

}
