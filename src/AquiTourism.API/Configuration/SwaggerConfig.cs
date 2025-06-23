using Microsoft.OpenApi.Models;

namespace AquiTourism.API.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "AquiTourism API",
                    Description = "Essa API é feita para gerenciamento de atrações para um site de turismo",
                    Contact = new OpenApiContact()
                    {
                        Name = "Nikolas Gomes",
                        Email = "nikolasgomes925@gmail.com"
                    }
                });
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("swagger/v1/swagger.json", "v1");
            });
        }
    }
}
