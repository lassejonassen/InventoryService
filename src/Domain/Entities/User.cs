namespace InventoryService.Domain.Entities;

public record User
{
	public required string UserId { get; init; }
	public required string DisplayName { get; init; }
	public required string Mail { get; init; }
	public required string ShortName { get; init; }
}

public record UnassignedUser : User
{
	public static UnassignedUser Create()
	{
		return new UnassignedUser {
			UserId = "UNASSIGNED-ID-17ABT-931",
			DisplayName = "Unassigned User",
			Mail = "unassigned@domainemail.com",
			ShortName = "UNASSIGNED"
		};
	}
}