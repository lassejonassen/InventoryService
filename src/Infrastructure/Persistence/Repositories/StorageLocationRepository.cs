using InventoryService.Domain.Entities;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Infrastructure.Persistence.Repositories;

public sealed class StorageLocationRepository : IStorageLocationRepository
{
	private readonly ApplicationDbContext _dbContext;

	public StorageLocationRepository(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext;
	}


	public async Task<Result> CreateStorageLocationAsync(StorageLocation storageLocation, CancellationToken cancellationToken = default)
	{
		await _dbContext.StorageLocations.AddAsync(storageLocation, cancellationToken);
		return Result.Success();
	}

	public async Task<Result<IEnumerable<StorageLocation>>> GetAllStorageLocationsAsync(CancellationToken cancellationToken = default)
	{
		return await _dbContext.StorageLocations.ToListAsync(cancellationToken);
	}

	public async Task<Result<StorageLocation>> GetStorageLocationByIdAsync(Guid id, CancellationToken cancellationToken = default)
	{
		var entity = await _dbContext.StorageLocations.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

		if (entity is null)
		{
			return Result.Failure<StorageLocation>(StorageLocationErrors.NotFound);
		}

		return entity!;
	}

	public async Task<Result> UpdateStorageLocationAsync(StorageLocation storageLocation, CancellationToken cancellationToken = default)
	{
		var entity = await _dbContext.StorageLocations.FirstOrDefaultAsync(e => e.Id == storageLocation.Id, cancellationToken);

		if (entity is null)
		{
			return Result.Failure<StorageLocation>(StorageLocationErrors.NotFound);
		}

		entity.Name = storageLocation.Name;
		entity.Description = storageLocation.Description;
		entity.UpdatedAt = DateTimeOffset.Now;
		entity.CorrelationId = Guid.NewGuid();

		_dbContext.Entry(entity).State = EntityState.Modified;

		return Result.Success();
	}

	public async Task<Result> DeleteStorageLocationAsync(Guid id, CancellationToken cancellationToken = default)
	{
		var entity = await _dbContext.StorageLocations.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

		if (entity is null)
		{
			return Result.Failure<StorageLocation>(StorageLocationErrors.NotFound);
		}

		_dbContext.StorageLocations.Remove(entity);
		return Result.Success();
	}
}
