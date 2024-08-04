using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Domain.Entities;

public sealed record Product : Entity
{
	public required string Name	{ get; set; }
	public string? Description { get; set; }
	public required string SKU { get; set; }
	public required ProductType ItemType { get; set; }
	public required Supplier Supplier { get; set; }
}
