using Es.PesquisaCep.DomainCore.Implementation;
using Es.PesquisaCep.DomainCore.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Es.PesquisaCep.DomainCore
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddDomainCore(this IServiceCollection services)
        {
            services.TryAddScoped<IEnviromentConfiguration, EnviromentConfiguration>();
            return services;
        }
    }
}
