using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Entities;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Application.Products.Commands.CreateProduct;

internal sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Guid>
{
	private readonly IProductRepository _productRepository;
	private readonly IProductTypeRepository _productTypeRepository;
	private readonly ISupplierRepository _supplierRepository;
	private readonly IUnitOfWork _unitOfWork;

	public CreateProductCommandHandler(
		IProductRepository productRepository,
		IProductTypeRepository productTypeRepository,
		ISupplierRepository supplierRepository,
		IUnitOfWork unitOfWork)
	{
		_productRepository = productRepository;
		_productTypeRepository = productTypeRepository;
		_supplierRepository = supplierRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
	{
		var productType = await _productTypeRepository.GetProductTypeByIdAsync(request.ProductTypeId, cancellationToken);

		if (productType.IsFailure)
		{
			return Result.Failure<Guid>(productType.Error);
		}

		var supplier = await _supplierRepository.GetByIdAsync(request.SupplierId, cancellationToken);

		if (supplier.IsFailure)
		{
			return Result.Failure<Guid>(supplier.Error);
		}

		Product product = new() {
			Id = Guid.NewGuid(),
			CorrelationId = Guid.NewGuid(),
			CreatedAt = DateTimeOffset.Now,
			UpdatedAt = null,
			Name = request.Name,
			Description = request.Description,
			SKU = request.SKU,
			ProductTypeId = productType.Value.Id,
			ProductType = productType.Value,
			SupplierId = supplier.Value.Id,
			Supplier = supplier.Value
		};

		await _productRepository.CreateAsync(product, cancellationToken);
		await _unitOfWork.SaveChangesAsync();

		return product.Id;
	}
}
