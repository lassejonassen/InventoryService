using InventoryService.Domain.Entities;
using InventoryService.Domain.Repositories;

namespace InventoryService.Infrastructure.Persistence.Repositories;

public class CommandRepository : ICommandRepository
{
	public Task<Guid> CreateCommandAsync(CommandCreate command)
	{
		throw new NotImplementedException();
	}

	public Task Retried(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task SetToDone(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task SetToFailed(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task SetToRetry(Guid id)
	{
		throw new NotImplementedException();
	}
}
