using InventoryService.Domain.Primitives;

namespace InventoryService.Domain.Entities;

public sealed record Status : Entity
{
	public required string Name { get; set; }
	public string? Description { get; set; }

	public Status? ParentStatus { get; set; }
	public Guid? ParentStatusId { get; set; }

	public ICollection<Status>? SubStatuses { get; set; }


	public static Status Create(string name, string? description = null, Status? parentStatus = null)
	{
		return new Status {
			Id = Guid.NewGuid(),
			CreatedAt = DateTimeOffset.Now,
			UpdatedAt = null,
			CorrelationId = Guid.NewGuid(),
			Name = name,
			Description = description,
			ParentStatus = parentStatus
		};
	}
}
