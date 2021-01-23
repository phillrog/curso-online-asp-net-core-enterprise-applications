using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace NSE.WebApp.MVC.Configurations
{
	public static class IdentityConfig
	{
		public static IServiceCollection AddIndetityConfiguration(this IServiceCollection services)
		{
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.LoginPath = "/login";
					options.AccessDeniedPath = "/acesso-negado";
				});
			return services;
		}

		public static IApplicationBuilder UseIndetityConfiguration(this IApplicationBuilder app)
		{
			app.UseAuthentication();
			app.UseAuthorization();
			return app;
		}
	}
}
