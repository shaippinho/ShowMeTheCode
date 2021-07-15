using Microsoft.Extensions.DependencyInjection;
using SMTC.API.CalculaJuros.Application.Interfaces;
using SMTC.API.CalculaJuros.Application.Services;

namespace SMTC.API.CalculaJuros.Configuration
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICalculaJurosService, CalculaJurosService>();
        }
    }
}
