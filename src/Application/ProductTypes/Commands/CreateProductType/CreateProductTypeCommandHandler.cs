using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Entities;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Application.ItemTypes.Commands.CreateItemType;

internal sealed class CreateProductTypeCommandHandler : ICommandHandler<CreateProductTypeCommand, Guid>
{
	private readonly IProductTypeRepository _repository;
	private readonly IUnitOfWork _unitOfOWork;

	public CreateProductTypeCommandHandler(IProductTypeRepository repository, IUnitOfWork unitOfOWork)
	{
		_repository = repository;
		_unitOfOWork = unitOfOWork;
	}

	public async Task<Result<Guid>> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
	{
		var itemType = new ProductType
		{
			Id = Guid.NewGuid(),
			CorrelationId = Guid.NewGuid(),
			CreatedAt = DateTimeOffset.Now,
			UpdatedAt = null,
			Name = request.Name,
		};

		await _repository.CreateProductTypeAsync(itemType, cancellationToken);
		await _unitOfOWork.SaveChangesAsync(cancellationToken);

		return itemType.Id;
	}
}
