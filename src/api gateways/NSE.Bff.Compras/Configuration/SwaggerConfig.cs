using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace NSE.Bff.Compras.Configuration
{
	public static class SwaggerConfig
	{
		public static void AppSwaggerConfiguration(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>

			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "NerdStore Enterprise API Gateway de Compras",
					Description = "Esta API faz parte do curso ASP.NET Core Enterprise Applications.",
					Contact = new OpenApiContact() { Name = "Phillipe", Email = "phillrog@hotmail.com" },
					License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
				});

				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = "Insira  o token  JWT desta maneira: Bearer {seu token}",
					Name = "Authorization",
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme {
							Reference = new OpenApiReference {
							Type = ReferenceType.SecurityScheme,
							Id = "Bearer"
							}
						},
						new string[] { }
					}
				});
			});



		}

		public static void UseSwaggerConfiguration(this IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("v1/swagger.json", "v1");
			});
		}
	}
}
