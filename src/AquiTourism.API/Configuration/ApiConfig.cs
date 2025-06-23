﻿using DevGames.API.Configuration;
using Serilog;

namespace AquiTourism.API.Configuration
{
    public static class ApiConfig
    {
        public static void ConfigureStartupConfiuration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(c => c.AddPolicy("MyPolicy",
                policy => policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));

            services.AddControllers();
            services.RegisterServices();
            AddJwtConfiguration(services);

            services.AddSwaggerGen();
            services.AddHttpContextAccessor();
            services.AddAutoMapper(AppDomain.CurrentDomain.Load("AquiTourism.Application"));
            services.DbContextConfigureServices(configuration);
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        private static void AddJwtConfiguration(IServiceCollection services)
        {
        }

        public static WebApplication UseStartupConfiguration(this WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("MyPolicy");

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();
            return app;
        }

        public static void ConfigureSerilog(this ConfigureHostBuilder builder)
        {
            builder.UseSerilog((ctx, lc) => lc.WriteTo.Console());
        }
    }
}
