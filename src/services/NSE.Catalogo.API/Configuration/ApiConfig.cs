using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSE.Catalogo.API.Data;
using NSE.WebAPI.Core.Identidade;
using System;

namespace NSE.Catalogo.API.Configuration
{
	public static class ApiConfig
	{
		public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			var conn = "";

			if (Environment.GetEnvironmentVariable("CONTAINER") == "true")
				conn = configuration.GetConnectionString("Container");
			else
				conn = configuration.GetConnectionString("Localhost");

			services.AddDbContext<CatalogoContext>(options =>
				options.UseSqlServer(conn, m => m.MigrationsAssembly("NSE.Catalogo.API")));

			services.AddControllers();

			services.AddCors(options => options.AddPolicy("Total", builder =>
			builder.AllowAnyOrigin()
			.AllowAnyHeader()
			.AllowAnyMethod()));


		}

		public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env, CatalogoContext catalogoContext)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			catalogoContext.Database.Migrate();

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseJwtConfiguration();

			app.UseCors("Total");

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
