using InventoryService.Domain.Entities;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Infrastructure.Persistence.Repositories;

public sealed class InventoryItemRepository : IInventoryItemRepository
{
	private readonly ApplicationDbContext _dbContext;

	public InventoryItemRepository(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public Task<Result> CreateAsync(InventoryItem item, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task<Result<IEnumerable<InventoryItem>>> GetAllAsync(CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task<Result<InventoryItem>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task<Result<InventoryItem>> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task<Result<IEnumerable<InventoryItem>>> GetByStorageLocationIdAsync(Guid storageLocationId, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task<Result> UpdateAsync(InventoryItem item, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}
