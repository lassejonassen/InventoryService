using InventoryService.Domain.Entities;
using InventoryService.Domain.Shared;

namespace InventoryService.Domain.Repositories;

public interface IItemTypeRepository
{
	Task<Result> CreateItemTypeAsync(ItemType itemType, CancellationToken cancellationToken);
	Task<Result<IEnumerable<ItemType>>> GetAllItemsAsync(CancellationToken cancellationToken);
	Task<Result<ItemType>> GetItemByIdAsync(Guid id, CancellationToken cancellationToken);
	Task<Result> UpdateItemTypeAsync(ItemType itemType, CancellationToken cancellationToken);
	Task<Result> DeleteItemTypeAsync(Guid id, CancellationToken cancellationToken);
}
