using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace NSE.Identidade.API.Configuration
{
	public static class ApiConfig
	{
		public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
		{
			services.AddControllers();

			//services.AddHttpsRedirection(options =>
			//{
			//	options.HttpsPort = 443;
			//});

			return services;
		}

		public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			//app.UseHttpsRedirection();

			app.UseRouting();

			app.UseIdentityConfiguration();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			return app;
		}
	}
}
