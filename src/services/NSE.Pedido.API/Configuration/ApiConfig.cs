using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSE.Pedidos.Infra.Data;
using NSE.WebAPI.Core.Identidade;
using System;

namespace NSE.Pedidos.API.Configuration
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

            services.AddDbContext<PedidosContext>(options =>
                options.UseSqlServer(conn, m => m.MigrationsAssembly("NSE.Pedidos.Infra")));

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("Total",
                    builder =>
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
            });
        }

        public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Total");

            app.UseJwtConfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}