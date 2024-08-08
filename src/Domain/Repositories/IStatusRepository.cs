using InventoryService.Domain.Entities;
using InventoryService.Domain.Shared;

namespace InventoryService.Domain.Repositories;

public interface IStatusRepository
{
	Task<Result<IEnumerable<Status>>> GetAllAsync(CancellationToken cancellationToken);
}
