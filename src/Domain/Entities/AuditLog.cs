namespace InventoryService.Domain.Entities;

public record AuditLog : Entity
{
	public required string EntityType { get; set; }
	public required string EntityId { get; set; }
	public string? ChangedByCommand { get; set; }
	public string? CommandId { get; set; }
	public string? ChangedByUser { get; set; }
	public required string Content { get; set; }
}

public record AuditLogCreate
{
	public required string EntityType { get; set; }
	public required string EntityId { get; set; }
	public string? ChangedByCommand { get; set; }
	public string? CommandId { get; set; }
	public string? ChangedByUser { get; set; }
	public required string Content { get; set; }
}