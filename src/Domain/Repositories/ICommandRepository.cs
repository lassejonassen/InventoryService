using InventoryService.Domain.Entities;

namespace InventoryService.Domain.Repositories;

public interface ICommandRepository
{
	Task<Guid> CreateCommandAsync(CommandCreate command);
	Task SetToRetry(Guid id);
	Task Retried(Guid id);
	Task SetToFailed(Guid id);
	Task SetToDone(Guid id);
}
