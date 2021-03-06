﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSE.Clientes.API.Data;
using NSE.WebAPI.Core.Identidade;
using System;

namespace NSE.Clientes.API.Configuration
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

            services.AddDbContext<ClientesContext>(options =>
                options.UseSqlServer(conn, m => m.MigrationsAssembly("NSE.Clientes.API")));

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

        public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env, ClientesContext clientesContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            clientesContext.Database.Migrate();

            app.UseHttpsRedirection();

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
