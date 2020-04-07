using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DependencyInjection
{
    public static class InMemoryDbExstension
    {
        public static IServiceCollection AddInMemoryDb(this IServiceCollection services)
        {
            services.AddScoped<DbContext, EventContext>((provider) =>
            {
                var options = new DbContextOptionsBuilder<EventContext>()
                    .UseInMemoryDatabase(databaseName: "inMemoryDb")
                    .Options;
                return new EventContext(options);
            });

            return services;
        }
    }
}
