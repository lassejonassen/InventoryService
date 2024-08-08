namespace InventoryService.Domain.Enums;

public enum ItemStatus
{
	InStock_Avaiable = 1,
	InStock_Reserved = 2,
	InStock_Allocated = 3,
	InStock_OnHold = 4,

	UnderInspection_QualityCheck = 5,
	UnderInspection_Damaged = 6,
}