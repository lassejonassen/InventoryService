using InventoryService.Application.Abstractions.Messaging;
using InventoryService.Domain.Entities;
using InventoryService.Domain.Repositories;
using InventoryService.Domain.Shared;

namespace InventoryService.Application.ItemTypes.Commands.CreateItemType;

internal sealed class CreateItemTypeCommandHandler : ICommandHandler<CreateItemTypeCommand, Guid>
{
	private readonly IItemTypeRepository _repository;
	private readonly IUnitOfWork _unitOfOWork;

	public CreateItemTypeCommandHandler(IItemTypeRepository repository, IUnitOfWork unitOfOWork)
	{
		_repository = repository;
		_unitOfOWork = unitOfOWork;
	}

	public async Task<Result<Guid>> Handle(CreateItemTypeCommand request, CancellationToken cancellationToken)
	{
		var itemType = new ItemType
		{
			Id = Guid.NewGuid(),
			CorrelationId = Guid.NewGuid(),
			CreatedAt = DateTimeOffset.Now,
			UpdatedAt = null,
			Name = request.Name,
		};

		await _repository.CreateItemTypeAsync(itemType, cancellationToken);
		await _unitOfOWork.SaveChangesAsync(cancellationToken);

		return itemType.Id;
	}
}
