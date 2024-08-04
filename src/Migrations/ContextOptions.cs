using CommandLine;

namespace InventoryService.Migrations;

public partial class DbContextFactory
{
	public class ContextOptions
	{
		[Option('c', "connectionstring", Required = false, HelpText = "Full connection string.")]
		public string Connectionstring { get; set; } =
				"Host=inventoryservice.database;Port=5432;Database=inventorydb;Username=postgres;Password=postgres;Include Error Detail=true";
	}
}