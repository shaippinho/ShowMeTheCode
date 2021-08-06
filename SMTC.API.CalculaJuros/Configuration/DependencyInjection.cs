using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SMTC.API.CalculaJuros.Application.Interfaces;
using SMTC.API.CalculaJuros.Application.Services;
using SMTC.Core.Notification;

namespace SMTC.API.CalculaJuros.Configuration
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationRequestBehavior<,>));
            services.AddMediatR(typeof(Startup));
            services.AddScoped<ICalculaJurosService, CalculaJurosService>();
            services.AddScoped<IDomainNotificationContext, DomainNotificationContext>();
        }
    }
}
