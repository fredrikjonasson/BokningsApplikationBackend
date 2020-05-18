using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace WebApi.DependencyInjection
{
    public static class SwaggerDocumentationExstension
    {
        public static IServiceCollection AddDocumentation(this IServiceCollection services)
        {
           services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Eventbokning", Version = "v1" });
           });

           return services;
        }

        public static IApplicationBuilder UseSwaggerDocs(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            return app;
        }
    }
}
