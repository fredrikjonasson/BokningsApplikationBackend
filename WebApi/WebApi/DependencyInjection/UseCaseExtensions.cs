using Domain.Events;
using Domain.Events.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DependencyInjection
{
    public static class UseCaseExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services) {
            services.AddScoped<IGetEvent, GetEvent>();
            services.AddScoped<IPostEvent, PostEvent>();
            services.AddScoped<IInvitation, Invitation>();
            return services;
        }
    }
}
