using Asp.Versioning;
using Carter;
using InventoryService.Application;
using InventoryService.Application.Statuses.Queries.GetAllStatuses;
using InventoryService.Infrastructure;
using InventoryService.Infrastructure.Persistence;
using InventoryService.Infrastructure.Persistence.Seeding;
using InventoryService.WebApi.Extensions;
using InventoryService.WebApi.Middleware;
using MediatR;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddAppConfiguration(builder.Configuration);
builder.AddApplicationInsights(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);

string applicationName = builder.Configuration.GetSection("Name").Value!;
string applicationVersion = builder.Configuration.GetSection("Version").Value!;

Console.WriteLine("""
	=== Warehouse Management System ===
	Service Name: {0}
	Service Version: {1}
	""", applicationName, applicationVersion);

builder.Host.AddSerilog(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCarter();

builder.Services
	.AddInfrastructure(builder.Configuration)
	.AddApplication();

builder.Services.AddProblemDetails();

builder.Services.AddApiVersioning(options => {
	options.DefaultApiVersion = new ApiVersion(1);
	options.ReportApiVersions = true;
	options.AssumeDefaultVersionWhenUnspecified = true;
	options.ApiVersionReader = ApiVersionReader.Combine(
		new UrlSegmentApiVersionReader(),
		new HeaderApiVersionReader("X-Api-Version"));
}).AddApiExplorer(options => {
	options.GroupNameFormat = "'v'V";
	options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	//app.ApplyMigrations(); // Uncomment method call if Docker Compose is not used.
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<RequestLogContextMiddleware>();
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseSerilogRequestLogging();

app.MapCarter();


app.MapPost("/seed", async (ApplicationDbContext context) => {
	await StatusesSeeder.SeedAsync(context, default);
});

app.MapGet("/status", async (ISender sender) => {
	var result = await sender.Send(new GetAllStatusesQuery());
	if (result.IsFailure)
	{
		return Results.Problem(
			title: result.Error.Title,
			detail: result.Error.Description,
			statusCode: StatusCodes.Status400BadRequest);
	}

	return Results.Ok(result.Value);
});

app.Run();
