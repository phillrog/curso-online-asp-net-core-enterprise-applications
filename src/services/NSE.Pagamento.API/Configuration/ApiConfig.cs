using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSE.Pagamentos.API.Data;
using NSE.Pagamentos.Facade;
using NSE.WebAPI.Core.Identidade;
using System;

namespace NSE.Pagamentos.API.Configuration
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

            services.AddDbContext<PagamentosContext>(options =>
               options.UseSqlServer(conn, m => m.MigrationsAssembly("NSE.Pagamento.API")));

            services.Configure<PagamentoConfig>(configuration.GetSection("PagamentoConfig"));

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

        public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env, PagamentosContext pagamentosContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            pagamentosContext.Database.Migrate();

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
