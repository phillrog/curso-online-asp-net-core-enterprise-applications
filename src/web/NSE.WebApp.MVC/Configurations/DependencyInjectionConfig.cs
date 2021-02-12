using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSE.WebAPI.Core.Usuario;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Services;
using NSE.WebApp.MVC.Services.Handlers;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using System;
using System.Net.Http;

namespace NSE.WebApp.MVC.Configurations
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton<IValidationAttributeAdapterProvider, CpfValidationAttributeAdapterProvider>();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped<IAspNetUser, AspNetUser>();

			services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

			#region HttpServices
			services.AddHttpClient<IAutenticacaoService, AutenticacaoService>()
				.AddPolicyHandler(PollyExtensions.EsperarTentar())
				.AddTransientHttpErrorPolicy(
					p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

			services.AddHttpClient<ICatalogoService, CatalogoService>()
				.AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
				.AddPolicyHandler(PollyExtensions.EsperarTentar())
				.AddTransientHttpErrorPolicy(
					p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

			services.AddHttpClient<ICarrinhoService, CarrinhoService>()
				.AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
				.AddPolicyHandler(PollyExtensions.EsperarTentar())
				.AddTransientHttpErrorPolicy(
					p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

			#endregion
			#region Refit

			//services.AddHttpClient("Refit",
			//        options =>
			//        {
			//            options.BaseAddress = new Uri(configuration.GetSection("CatalogoUrl").Value);
			//        })
			//    .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
			//    .AddTypedClient(Refit.RestService.For<ICatalogoServiceRefit>);

			#endregion
		}
	}

	public class PollyExtensions
	{
		public static AsyncRetryPolicy<HttpResponseMessage> EsperarTentar()
		{
			var retry = HttpPolicyExtensions
				.HandleTransientHttpError()
				.WaitAndRetryAsync(new[]
				{
					TimeSpan.FromSeconds(1),
					TimeSpan.FromSeconds(5),
					TimeSpan.FromSeconds(10),
				}, (outcome, timespan, retryCount, context) =>
				{
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.WriteLine($"Tentando pela {retryCount} vez!");
					Console.ForegroundColor = ConsoleColor.White;
				});

			return retry;
		}
	}
}
