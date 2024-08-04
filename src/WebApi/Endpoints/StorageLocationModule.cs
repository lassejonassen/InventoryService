using Carter;
using InventoryService.Application.StorageLocations.Commands.CreateStorageLocation;
using InventoryService.Application.StorageLocations.Commands.DeleteStorageLocation;
using InventoryService.Application.StorageLocations.Commands.UpdateStorageLocation;
using InventoryService.Application.StorageLocations.Queries.GetAllStorageLocations;
using InventoryService.Application.StorageLocations.Queries.GetStorageLocationById;
using MediatR;

namespace InventoryService.WebApi.Endpoints;

public class StorageLocationModule : CarterModule
{
	public StorageLocationModule()
		: base("/api/storage-locations")
	{
		WithTags("Storage Locations");
		WithMetadata(new { Description = "Storage Locations API" });
	}

	public override void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPost("/", async (CreateStorageLocationCommand command, ISender sender) => {
			var result = await sender.Send(command);
			return result.IsSuccess
				? Results.Ok(result.Value.ToString())
				: Results.BadRequest(result.Error);
		});

		app.MapGet("/", async (ISender sender) => {
			var result = await sender.Send(new GetAllStorageLocationsQuery());
			return result.IsSuccess
				? Results.Ok(result.Value)
				: Results.BadRequest(result.Error);
		});

		app.MapGet("/{id:guid}", async (Guid id, ISender sender) => {
			var result = await sender.Send(new GetStorageLocationByIdQuery(id));
			return result.IsSuccess
				? Results.Ok(result.Value)
				: Results.NotFound();
		});

		app.MapPatch("/", async (UpdateStorageLocationCommand command, ISender sender) => {
			var result = await sender.Send(command);
			return result.IsSuccess
				? Results.Ok()
				: Results.BadRequest(result.Error);
		});

		app.MapDelete("/{id:guid}", async (Guid id, ISender sender) => {
			var result = await sender.Send(new DeleteStorageLocationCommand(id));
			return result.IsSuccess
				? Results.NoContent()
				: Results.BadRequest(result.Error);
		});
	}
}
