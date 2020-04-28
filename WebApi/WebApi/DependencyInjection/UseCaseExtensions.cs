using Domain.Events;
using Domain.Events.Interfaces;
using Domain.Interfaces;
using Domain.Invitations;
using Domain.Invitations.UseCases;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DependencyInjection
{
    public static class UseCaseExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services) {
            services.AddScoped<IGetEvent, GetEvent>();
            services.AddScoped<IPostEvent, PostEvent>();
            services.AddScoped<IEventFactory, Infrastructure.EventFactory>();

            services.AddScoped<IUseCase<InvitationInput>, SendInvitesUseCase>();
            services.AddScoped<IInvitationFactory, InvitationFactory>();

            return services;
        }
    }
}
