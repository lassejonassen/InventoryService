using InventoryService.Domain.Entities;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Infrastructure.Persistence.Repositories;

public sealed class ProductRepository : IProductRepository
{
	private readonly ApplicationDbContext _dbContext;

	public ProductRepository(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public Task<Result> CreateAsync(Product product, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task<Result<IEnumerable<Product>>> GetAllAsync(CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task<Result<Product>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task<Result> UpdateAsync(Product product, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}
