using Carter;
using InventoryService.Application.Suppliers.Commands.CreateSupplier;
using InventoryService.Application.Suppliers.Commands.DeleteSupplier;
using InventoryService.Application.Suppliers.Commands.UpdateSupplier;
using InventoryService.Application.Suppliers.Queries.GetAllSuppliers;
using InventoryService.Application.Suppliers.Queries.GetSupplierById;
using InventoryService.Application.Suppliers.Queries.GetSupplierByName;
using MediatR;

namespace InventoryService.WebApi.Endpoints;

public class SupplierModule : CarterModule
{
	public SupplierModule()
		: base("/api/suppliers")
	{
		WithTags("Suppliers");
	}

	public override void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPost("/", async (CreateSupplierCommand command, ISender sender) => {
			var result = await sender.Send(command);

			if (result.IsFailure)
			{
				return Results.Problem(title: result.Error.Title, detail: result.Error.Description, statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok(result.Value);
		});

		app.MapGet("/", async (ISender sender) => {
			var result = await sender.Send(new GetAllSuppliersQuery());

			if (result.IsFailure)
			{
				return Results.Problem(title: result.Error.Title, detail: result.Error.Description, statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok(result.Value);
		}).WithDescription("Get all suppliers");

		app.MapGet("/{id:guid}", async(Guid id, ISender sender) => {
			var result = await sender.Send(new GetSupplierByIdQuery(id));

			if (result.IsFailure)
			{
				return Results.Problem(title: result.Error.Title, detail: result.Error.Description, statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok(result.Value);
		}).WithDescription("Get a supplier by id");

		app.MapGet("/name", async(string name, ISender sender) => {
			var result = await sender.Send(new GetSupplierByNameQuery(name));

			if (result.IsFailure)
			{
				return Results.Problem(title: result.Error.Title, detail: result.Error.Description, statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok(result.Value);
		}).WithDescription("Get a supplier by name");

		app.MapPatch("/", async(UpdateSupplierCommand command, ISender sender) => {
			var result = await sender.Send(command);

			if (result.IsFailure)
			{
				return Results.Problem(title: result.Error.Title, detail: result.Error.Description, statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok();
		}).WithDescription("Update a supplier");

		app.MapDelete("/{id:guid}", async(Guid id, ISender sender) => {
			var result = await sender.Send(new DeleteSupplierCommand(id));

			if (result.IsFailure)
			{
				return Results.Problem(title: result.Error.Title, detail: result.Error.Description, statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok();
		}).WithDescription("Delete a supplier");
	}
}
