using InventoryService.Domain.Entities;

namespace InventoryService.Application;

public record ActionContext(string userShortName = "", User? user = null)
{
	public required string UserShortName { get; set; } = userShortName;
	public User? User = user;
}
