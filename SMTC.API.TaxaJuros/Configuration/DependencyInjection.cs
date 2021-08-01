using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SMTC.API.TaxaJuros.Application.Interfaces;
using SMTC.API.TaxaJuros.Application.Queries;

namespace SMTC.API.TaxaJuros.Configuration
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
            services.AddScoped<ITaxaJurosQuery, TaxaJurosQuery>();
        }
    }
}
