using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSE.MessageBus
{
	public static class DependencyInjectionExtensions
	{
		public static IServiceCollection AddMessageBus(this IServiceCollection services, string connection)
		{
			if (string.IsNullOrEmpty(connection)) throw new ArgumentNullException();

			services.AddSingleton<IMessageBus>(new MessageBus(connection));

			return services;
		}
	}
}
