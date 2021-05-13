using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace NSE.Carrinho.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseKestrel(opts =>
					{
						opts.ListenAnyIP(4004, opts => opts.Protocols = HttpProtocols.Http1);
						opts.ListenAnyIP(5004, opts => { opts.Protocols = HttpProtocols.Http1; });
						opts.ListenAnyIP(4014, opts => opts.Protocols = HttpProtocols.Http2);
					});
					
					webBuilder.UseStartup<Startup>();
				});
	}
}
