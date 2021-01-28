using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Services;
using NSE.WebApp.MVC.Services.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Configurations
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

			services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

			//services.AddHttpClient<ICatalogoService, CatalogoService>()
			//	.AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

			services.AddHttpClient("Refit", options => {
				options.BaseAddress = new Uri(configuration.GetSection("CatalogoUrl").Value);

			}).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
			.AddTypedClient(Refit.RestService.For<ICatalogoServiceRefit>);

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			services.AddScoped<IUser, AspNetUser>();
		}
	}
}
