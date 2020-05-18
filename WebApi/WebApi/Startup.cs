using Domain.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.Configuration;
using WebApi.DependencyInjection;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddUseCases();
            services.AddInMemoryDb();
            services.AddDocumentation();
            services.AddScoped<IEmailService, EmailService>();
            services.Configure<EmailSettings>(Configuration.GetSection("Email"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Middleware gör att vårt api inte fungerar.
            //app.UseMiddleware<MiddlewareExceptionHandler>();

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseSwaggerDocs();
            
            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors(builder =>
            {
                builder.WithOrigins(Configuration.GetValue<string>("AllowedHosts"));
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
