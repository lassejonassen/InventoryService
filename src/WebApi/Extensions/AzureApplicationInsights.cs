using Microsoft.ApplicationInsights.AspNetCore.Extensions;

namespace InventoryService.WebApi.Extensions;

public static class AzureApplicationInsights
{
	public const string SectionName = "AppSettings:ConnectionStrings:AppInsights";

	public static void AddApplicationInsights(this WebApplicationBuilder builder, IConfiguration configuration)
	{
		string? appInsightsConnectionString = configuration.GetSection(SectionName).Value;

		if (appInsightsConnectionString is not null)
		{
			Console.WriteLine("Using Azure ApplicationInsights");
			ApplicationInsightsServiceOptions options = new() { ConnectionString = appInsightsConnectionString };
			builder.Services.AddApplicationInsightsTelemetry(options);
		}
	}
}
