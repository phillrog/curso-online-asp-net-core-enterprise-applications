﻿using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using NSE.Core.Mediator;
using NSE.WebAPI.Core.Usuario;

namespace NSE.Pagamentos.API.Configuration
{
	public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();
        }
    }
}
