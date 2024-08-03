using Asp.Versioning;
using Carter;
using InventoryService.Application;
using InventoryService.Infrastructure;
using InventoryService.WebApi.Extensions;
using InventoryService.WebApi.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) =>
	loggerConfig.ReadFrom.Configuration(context.Configuration));

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
	//app.ApplyMigrations();
}

app.UseHttpsRedirection();
app.UseMiddleware<RequestLogContextMiddleware>();
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseSerilogRequestLogging();

app.MapCarter();

app.Run();