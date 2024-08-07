using InventoryService.Domain.Entities;
using InventoryService.Domain.Errors;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Infrastructure.Persistence.Repositories;

public sealed class SupplierRepository : ISupplierRepository
{
	private readonly ApplicationDbContext _dbContext;

	public SupplierRepository(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Result> AddAsync(Supplier supplier, CancellationToken cancellationToken)
	{
		await _dbContext.Suppliers.AddAsync(supplier, cancellationToken);

		return Result.Success();
	}

	public async Task<Result<IEnumerable<Supplier>>> GetAllAsync(CancellationToken cancellationToken)
	{
		return await _dbContext.Suppliers.ToListAsync(cancellationToken);
	}

	public async Task<Result<Supplier>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Suppliers.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

		if (entity is null)
		{
			return Result.Failure<Supplier>(SupplierErrors.NotFound);
		}

		return entity;
	}

	public async Task<Result<Supplier>> GetByNameAsync(string name, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Suppliers.FirstOrDefaultAsync(x => x.Name == name, cancellationToken);

		if (entity is null)
		{
			return Result.Failure<Supplier>(SupplierErrors.NotFoundByName);
		}

		return entity;
	}

	public async Task<Result> UpdateAsync(Supplier supplier, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Suppliers.FirstOrDefaultAsync(x => x.Id == supplier.Id, cancellationToken);

		if (entity is null)
		{
			return Result.Failure<Supplier>(SupplierErrors.NotFound);
		}

		entity.Name = supplier.Name;
		entity.Street = supplier.Street;
		entity.City = supplier.City;
		entity.State = supplier.State;
		entity.PostalCode = supplier.PostalCode;
		entity.Country = supplier.Country;
		entity.Phone = supplier.Phone;
		entity.Email = supplier.Email;

		_dbContext.Entry(entity).State = EntityState.Modified;
		
		return Result.Success();
	}

	public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Suppliers.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

		if (entity is null)
		{
			return Result.Failure<Supplier>(SupplierErrors.NotFound);
		}

		_dbContext.Suppliers.Remove(entity);
		return Result.Success();
	}

	public async Task<bool> IsNameUnique(string name, CancellationToken cancellationToken)
	{
		var exists = await _dbContext.Suppliers.AnyAsync(x => x.Name == name, cancellationToken);
		return !exists;
	}
}
