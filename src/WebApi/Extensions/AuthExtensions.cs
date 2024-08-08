using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

namespace InventoryService.WebApi.Extensions;

public static class AuthExtensions
{
	public const string Enabled = "AppSettings:Auth:Enabled";
	public const string AzureAd = "AppSettings:Auth:AzureAd";

	public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
	{
		bool enabled = configuration.GetValue<bool>(Enabled);

		if (enabled)
		{
            Console.WriteLine("Authentication and Authorization is enabled");
			services.AddAzureActiveDirectory(configuration);

		} else
		{
            Console.WriteLine("Authentication and Authoization is disabled");
        }
	}


	private static void AddAzureActiveDirectory(this IServiceCollection services, IConfiguration configuration)
	{
		bool exists = configuration.GetSection(AzureAd).Exists();

		if (exists)
		{
            Console.WriteLine("Adding Microsoft Entra ID as an Authentication option");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddMicrosoftIdentityWebApi(
			options => {
				configuration.Bind(AzureAd, options);

				options.TokenValidationParameters.NameClaimType = "name";
			},
			options => { configuration.Bind(AzureAd, options); });
		}
	}
}
