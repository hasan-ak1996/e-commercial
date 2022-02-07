using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace e_commercial_API.Extensions
{
    public static class SwaggerDocumentaionExtension
    {
        public static IServiceCollection AddSwaggerDocumentaion(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "e_commercial_API", Version = "v1" });
            });
            return services;
        }
        public static IApplicationBuilder UseSwaggerDocumentaion(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "e_commercial_API v1"));
            return app;
        }
    }
}
