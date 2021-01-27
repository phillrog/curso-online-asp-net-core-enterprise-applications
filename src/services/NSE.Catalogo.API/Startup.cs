using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSE.Catalogo.API.Configuration;
using Microsoft.Extensions.Hosting;
using NSE.WebAPI.Core.Identidade;

namespace NSE.Catalogo.API
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IHostEnvironment hostEnvironment)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(hostEnvironment.ContentRootPath)
				.AddJsonFile("appsettings.json", true, true)
				.AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
				.AddEnvironmentVariables();

			if (hostEnvironment.IsDevelopment())
			{
				builder.AddUserSecrets<Startup>();
			}

			Configuration = builder.Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddApiConfiguration(Configuration);

			services.AddJwtConfiguration(Configuration);

			services.AppSwaggerConfiguration();

			services.RegistrarServices();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseSwaggerConfiguration();
			app.UseApiConfiguration(env);
		}
	}
}
