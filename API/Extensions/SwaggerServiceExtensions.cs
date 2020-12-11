using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            //Add Swagger UI for documentation
            services.AddSwaggerGen(x=> 
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "SkiNet API", Version = "v1" });
            });
            
            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            //Use Swagger UI for documentation
            app.UseSwagger();
            app.UseSwaggerUI(x=> 
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "SkiNet API v1");
            });

            return app;
        }

    }
}