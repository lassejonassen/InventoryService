using System;
using InventoryService.Infrastructure.Persistence;
using InventoryService.Infrastructure.Persistence.Seeding;

namespace InventoryService.WebApi.Extensions;

/// <summary>
/// Extension is responsible for seeding the database.
/// </summary>
public static class SeedingExtension
{
	public static async Task SeedDatabase(this IApplicationBuilder app)
	{
		var dbContext
				= app.ApplicationServices.CreateScope()
				.ServiceProvider.GetRequiredService<ApplicationDbContext>();

		await StatusesSeeder.SeedAsync(dbContext, CancellationToken.None);
	}
}
