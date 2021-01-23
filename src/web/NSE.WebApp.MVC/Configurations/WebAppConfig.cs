using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSE.WebApp.MVC.Extensions;

namespace NSE.WebApp.MVC.Configurations
{
	public static class WebAppConfig
	{
		public static IServiceCollection AddWebAppConfiguration(this IServiceCollection services)
		{
			services.AddControllersWithViews();
			return services;
		}

		public static IApplicationBuilder UseWebAppConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/erro/500");
				app.UseStatusCodePagesWithRedirects("/erro/{0}");
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseIndetityConfiguration();

			app.UseMiddleware<ExceptionMiddleware>();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
			
			return app;
		}
	}
}
