using InventoryService.Domain.Repositories;
using InventoryService.Infrastructure.Options;
using InventoryService.Infrastructure.Persistence;
using InventoryService.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

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
		services.ConfigureOptions<DatabaseOptionsSetup>();

		services.AddDbContext<ApplicationDbContext>(
			(serviceProvider, dbContextOptionsBuilder) => {
				var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;


				dbContextOptionsBuilder.UseNpgsql(databaseOptions.ConnectionString, action => {
					action.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
					action.CommandTimeout(databaseOptions.CommandTimeout);
				});
				dbContextOptionsBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
				dbContextOptionsBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
			});


		services.AddScoped<IUnitOfWork, UnitOfWork>();
		services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
		services.AddScoped<IProductRepository, ProductRepository>();
		services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
		services.AddScoped<IStorageLocationRepository, StorageLocationRepository>();
		services.AddScoped<ISupplierRepository, SupplierRepository>();

		return services;
	}

	private static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
	{
		
		return services;
	}
}
