using InventoryService.Domain.Entities;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Infrastructure.Persistence.Repositories;

public sealed class ItemTypeRepository : IItemTypeRepository
{
	private readonly ApplicationDbContext _dbContext;

	public ItemTypeRepository(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Result> CreateItemTypeAsync(ItemType itemType, CancellationToken cancellationToken)
	{
		await _dbContext.ItemTypes.AddAsync(itemType, cancellationToken);
		return Result.Success();
	}

	public async Task<Result<IEnumerable<ItemType>>> GetAllItemsAsync(CancellationToken cancellationToken)
	{
		return await _dbContext.ItemTypes.ToListAsync(cancellationToken);
	}

	public async Task<Result<ItemType>> GetItemByIdAsync(Guid id, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.ItemTypes.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

		if (entity is null)
		{
			return Result.Failure<ItemType>(ItemTypeErrors.NotFound);
		}

		return entity!;
	}

	public async Task<Result> UpdateItemTypeAsync(ItemType itemType, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.ItemTypes.FirstOrDefaultAsync(e => e.Id == itemType.Id, cancellationToken);

		if (entity is null)
		{
			return Result.Failure<ItemType>(ItemTypeErrors.NotFound);
		}

		entity.Name = itemType.Name;
		entity.UpdatedAt = DateTimeOffset.Now;
		entity.CorrelationId = Guid.NewGuid();

		_dbContext.Entry(entity).State = EntityState.Modified;

		return Result.Success();
	}

	public async Task<Result> DeleteItemTypeAsync(Guid id, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.ItemTypes.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

		if (entity is null)
		{
			return Result.Failure<StorageLocation>(StorageLocationErrors.NotFound);
		}

		_dbContext.ItemTypes.Remove(entity);
		return Result.Success();
	}
}
