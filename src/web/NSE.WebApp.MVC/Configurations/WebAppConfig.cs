using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSE.WebApp.MVC.Extensions;
using System.Globalization;

namespace NSE.WebApp.MVC.Configurations
{
	public static class WebAppConfig
	{
		public static void AddWebAppConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddControllersWithViews();
			services.Configure<AppSettings>(configuration);

		}

		public static void UseWebAppConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
		{
			//if (env.IsDevelopment())
			//{
			//	app.UseDeveloperExceptionPage();
			//}
			//else
			//{
			//}
			app.UseExceptionHandler("/erro/500");
			app.UseStatusCodePagesWithRedirects("/erro/{0}");
			app.UseHsts();
			//app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseIndetityConfiguration();

			var supportedCultures = new[] { new CultureInfo("pt-BR") };
			app.UseRequestLocalization(new RequestLocalizationOptions
			{
				DefaultRequestCulture = new RequestCulture("pt-BR"),
				SupportedCultures = supportedCultures,
				SupportedUICultures = supportedCultures
			});

			app.UseMiddleware<ExceptionMiddleware>();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Catalogo}/{action=Index}/{id?}");
			});
		}
	}
}
