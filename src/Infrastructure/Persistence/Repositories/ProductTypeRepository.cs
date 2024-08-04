using InventoryService.Domain.Entities;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Infrastructure.Persistence.Repositories;

public sealed class ProductTypeRepository : IProductTypeRepository
{
	private readonly ApplicationDbContext _dbContext;

	public ProductTypeRepository(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Result> CreateProductTypeAsync(ProductType itemType, CancellationToken cancellationToken)
	{
		await _dbContext.ItemTypes.AddAsync(itemType, cancellationToken);
		return Result.Success();
	}

	public async Task<Result<IEnumerable<ProductType>>> GetAllProductTypesAsync(CancellationToken cancellationToken)
	{
		return await _dbContext.ItemTypes.ToListAsync(cancellationToken);
	}

	public async Task<Result<ProductType>> GetProductTypeByIdAsync(Guid id, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.ItemTypes.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

		if (entity is null)
		{
			return Result.Failure<ProductType>(ProductTypeErrors.NotFound);
		}

		return entity!;
	}

	public async Task<Result> UpdateProductTypeAsync(ProductType itemType, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.ItemTypes.FirstOrDefaultAsync(e => e.Id == itemType.Id, cancellationToken);

		if (entity is null)
		{
			return Result.Failure<ProductType>(ProductTypeErrors.NotFound);
		}

		entity.Name = itemType.Name;
		entity.UpdatedAt = DateTimeOffset.Now;
		entity.CorrelationId = Guid.NewGuid();

		_dbContext.Entry(entity).State = EntityState.Modified;

		return Result.Success();
	}

	public async Task<Result> DeleteProductTypeAsync(Guid id, CancellationToken cancellationToken)
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
