using InventoryService.Domain.Entities;
using InventoryService.Domain.Shared;

namespace InventoryService.Domain.Repositories;

public interface IProductRepository
{
	Task<Result> CreateAsync(Product product, CancellationToken cancellationToken);
	Task<Result<IEnumerable<Product>>> GetAllAsync(CancellationToken cancellationToken);
	Task<Result<Product>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
	Task<Result> UpdateAsync(Product product, CancellationToken cancellationToken);
	Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken);
}
