using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SMTC.API.TaxaJuros.Application.Commands;
using SMTC.API.TaxaJuros.Application.DTO;
using SMTC.API.TaxaJuros.Application.Queries;
using SMTC.Core.Notification;

namespace SMTC.API.TaxaJuros.Configuration
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationRequestBehavior<,>));
            services.AddMediatR(typeof(Startup));
            services.AddScoped<IRequestHandler<TaxaJurosQuery, TaxaJurosDTO>, TaxaJurosQueryHandler>();
            services.AddScoped<AsyncRequestHandler<TaxaJurosUpdateCommand>, TaxaJurosCommandHandler>();
            services.AddScoped<IValidator<TaxaJurosUpdateCommand>, TaxaJurosUpdateValidation>();
            services.AddScoped<IDomainNotificationContext, DomainNotificationContext>();
        }
    }
}
