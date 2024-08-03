using InventoryService.Domain.Entities;
using InventoryService.Domain.Shared;

namespace InventoryService.Domain.Repositories;

public interface IStorageLocationRepository
{
	Task<Result> CreateStorageLocationAsync(StorageLocation storageLocation, CancellationToken cancellationToken = default);
	Task<Result<IEnumerable<StorageLocation>>> GetAllStorageLocationsAsync(CancellationToken cancellationToken = default);
	Task<Result<StorageLocation>> GetStorageLocationByIdAsync(Guid id, CancellationToken cancellationToken = default);
	Task<Result> UpdateStorageLocationAsync(StorageLocation storageLocation, CancellationToken cancellationToken = default);
	Task<Result> DeleteStorageLocationAsync(Guid id, CancellationToken cancellationToken = default);
}
