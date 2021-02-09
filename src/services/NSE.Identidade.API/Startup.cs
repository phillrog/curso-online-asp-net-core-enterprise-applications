using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSE.Identidade.API.Data;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using NSE.Identidade.API.Configuration;

namespace NSE.Identidade.API
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

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddIdentityConfiguration(Configuration);			
			services.AddApiConfiguration();
			services.AppSwaggerConfiguration();
			services.AddMessageBusConfiguration(Configuration);
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext applicationDbContext)
		{
			app.UseSwaggerConfiguration();		
			app.UseApiConfiguration(env);
			app.UseIdentityConfiguration(applicationDbContext);
		}
	}
}
