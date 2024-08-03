using InventoryService.Domain.Enums;

namespace InventoryService.Domain.Entities;

public record Command : Entity
{
	public required string ContentType { get; set; }
	public required CommandState CommandState { get; set; }
	public required Direction Direction { get; set; }
	public string? Counterpart { get; set; }
	public required string Content { get; set; }
	public string? User { get; set; }
	public required int Retries { get; set; }
	public DateTimeOffset? RetryAfter { get; set; }
}

public record CommandCreate
{
	public required string ContentType { get; set; }
	public required Direction Direction { get; set; }
	public string? Counterpart { get; set; }
	public required string Content { get; set; }
	public string? User { get; set; }
	public required Guid CorrelationId { get; set; }
}