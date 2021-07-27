using Es.PesquisaCep.Application.Implementation;
using Es.PesquisaCep.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Es.PesquisaCep.Application
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.TryAddScoped<IAccountApplication, AccountApplication>();
            services.TryAddScoped<ITokenApplication, TokenApplication>();
            services.TryAddScoped<IPesquisaCepApplication, PesquisaCepApplication>();
            return services;
        }
    }
}
