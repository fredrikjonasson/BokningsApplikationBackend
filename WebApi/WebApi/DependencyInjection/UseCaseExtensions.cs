using Domain.Events;
using Domain.Events.Interfaces;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DependencyInjection
{
    public static class UseCaseExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services) {
            services.AddScoped<IGetEvent, GetEvent>();
            services.AddScoped<IPostEvent, PostEvent>();
            services.AddScoped<IEventFactory, EntitiesFactory>();
            return services;
        }
    }
}
