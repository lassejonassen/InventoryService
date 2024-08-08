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
		RequireAuthorization();
	}

	public override void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPost("/", async (CreateStorageLocationCommand command, ISender sender) => {
			var result = await sender.Send(command);

			if (result.IsFailure)
			{
				return Results.Problem(
					title: result.Error.Title,
					detail: result.Error.Description,
					statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok(result.Value);
		});

		app.MapGet("/", async (ISender sender) => {
			var result = await sender.Send(new GetAllStorageLocationsQuery());
			if (result.IsFailure)
			{
				return Results.Problem(
					title: result.Error.Title,
					detail: result.Error.Description,
					statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok(result.Value);
		});

		app.MapGet("/{id:guid}", async (Guid id, ISender sender) => {
			var result = await sender.Send(new GetStorageLocationByIdQuery(id));
			if (result.IsFailure)
			{
				return Results.Problem(
					title: result.Error.Title,
					detail: result.Error.Description,
					statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok(result.Value);
		});

		app.MapPatch("/", async (UpdateStorageLocationCommand command, ISender sender) => {
			var result = await sender.Send(command);
			if (result.IsFailure)
			{
				return Results.Problem(
					title: result.Error.Title,
					detail: result.Error.Description,
					statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok();
		});

		app.MapDelete("/{id:guid}", async (Guid id, ISender sender) => {
			var result = await sender.Send(new DeleteStorageLocationCommand(id));
			if (result.IsFailure)
			{
				return Results.Problem(
					title: result.Error.Title,
					detail: result.Error.Description,
					statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok();
		});
	}
}
