using InventoryService.Domain.Entities;
using InventoryService.Domain.Shared;

namespace InventoryService.Domain.Repositories;

public interface IProductTypeRepository
{
	Task<Result> CreateProductTypeAsync(ProductType itemType, CancellationToken cancellationToken);
	Task<Result<IEnumerable<ProductType>>> GetAllProductTypesAsync(CancellationToken cancellationToken);
	Task<Result<ProductType>> GetProductTypeByIdAsync(Guid id, CancellationToken cancellationToken);
	Task<Result> UpdateProductTypeAsync(ProductType itemType, CancellationToken cancellationToken);
	Task<Result> DeleteProductTypeAsync(Guid id, CancellationToken cancellationToken);
}
