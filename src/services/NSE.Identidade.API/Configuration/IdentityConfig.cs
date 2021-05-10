using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Security.JwtSigningCredentials;
using NSE.Identidade.API.Data;
using NSE.Identidade.API.Extensions;
using NSE.WebAPI.Core.Identidade;
using System;

namespace NSE.Identidade.API.Configuration
{
	public static class IdentityConfig
	{
		public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			var conn = "";

			if (Environment.GetEnvironmentVariable("CONTAINER") == "true")
				conn = configuration.GetConnectionString("Container");
			else
				conn = configuration.GetConnectionString("Localhost");

			var appSettingsSection = configuration.GetSection("AppTokenSettings");
			services.Configure<AppTokenSettings>(appSettingsSection);

			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(conn));

			services.AddJwksManager(options => options.Algorithm = Algorithm.ES256)
				.PersistKeysToDatabaseStore<ApplicationDbContext>();

			services.AddDefaultIdentity<IdentityUser>()
				.AddRoles<IdentityRole>()
				.AddErrorDescriber<IdentityMensagensPortugues>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			//services.AddJwtConfiguration(configuration);

			return services;
		}

		public static void UseIdentityConfiguration(this IApplicationBuilder app, ApplicationDbContext  applicationDbContext)
		{
			applicationDbContext.Database.Migrate();
		}
	}
}
