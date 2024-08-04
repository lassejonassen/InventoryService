using InventoryService.Domain.Repositories;
using InventoryService.Infrastructure.Persistence;
using InventoryService.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryService.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddPersistence(configuration);
		return services;
	}

	private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
	{
		string connectionString = configuration.GetSection("ConnectionStrings:Database").Value
			?? throw new Exception("Database connection string is missing from configuration.");

		services.AddDbContext<ApplicationDbContext>(options =>
			options.UseNpgsql(connectionString));
		services.AddScoped<IUnitOfWork, UnitOfWork>();
		services.AddScoped<IAuditLogRepository, AuditLogRepository>();
		services.AddScoped<ICommandRepository, CommandRepository>();
		services.AddScoped<IStorageLocationRepository, StorageLocationRepository>();
		services.AddScoped<IProductTypeRepository, ProductTypeRepository>();

		return services;
	}
}
