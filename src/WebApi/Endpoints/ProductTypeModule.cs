using Carter;
using InventoryService.Application.ItemTypes.Commands.CreateItemType;
using InventoryService.Application.ItemTypes.Commands.DeleteItemType;
using InventoryService.Application.ItemTypes.Commands.UpdateItemType;
using InventoryService.Application.ItemTypes.Queries.GetAllItemTypes;
using InventoryService.Application.ItemTypes.Queries.GetItemTypeById;
using MediatR;

namespace InventoryService.WebApi.Endpoints;

public class ProductTypeModule : CarterModule
{

	public ProductTypeModule()
		: base("/api/product-types")
	{
		WithTags("Product Types");
	}

	public override void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapPost("/", async (CreateProductTypeCommand command, ISender sender) => {
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
			var result = await sender.Send(new GetAllProductTypesQuery());
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
			var result = await sender.Send(new GetProductTypeByIdQuery(id));
			if (result.IsFailure)
			{
				return Results.Problem(
					title: result.Error.Title,
					detail: result.Error.Description,
					statusCode: StatusCodes.Status400BadRequest);
			}

			return Results.Ok(result.Value);
		});

		app.MapPatch("/", async (UpdateProductTypeCommand command, ISender sender) => {
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
			var result = await sender.Send(new DeleteProductTypeCommand(id));
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
