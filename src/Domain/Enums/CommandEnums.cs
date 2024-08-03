namespace InventoryService.Domain.Enums;

public enum Direction
{
	In,
	Out,
}

public enum CommandState
{
	New,
	Retry,
	Done,
	Failed,
}