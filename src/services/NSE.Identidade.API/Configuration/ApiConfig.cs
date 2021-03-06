﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NSE.WebAPI.Core.Identidade;
using NetDevPack.Security.JwtSigningCredentials.AspNetCore;
using NSE.WebAPI.Core.Usuario;
using NSE.Identidade.API.Services;

namespace NSE.Identidade.API.Configuration
{
	public static class ApiConfig
	{
		public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
		{
			services.AddControllers();

            //services.AddHttpsRedirection(options =>
            //{
            //    options.HttpsPort = 5001;
            //});

            services.AddScoped<AuthenticationService>();
            services.AddScoped<IAspNetUser, AspNetUser>();

			return services;
		}

		public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseHttpsRedirection();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHsts();

			app.UseRouting();

			app.UseJwtConfiguration();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseJwksDiscovery();

			return app;
		}
	}
}
