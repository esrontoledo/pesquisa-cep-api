using Es.PesquisaCep.Application;
using Es.PesquisaCep.DomainCore;
using Es.PesquisaCep.DomainCore.Interfaces;
using Es.PesquisaCep.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Es.PesquisaCep.IoC.IoC
{
    public static class DependencyResolver
    {
        public static IServiceCollection AddDependencyResolver(this IServiceCollection services, IEnviromentConfiguration enviromentConfiguration)
        {
            services.AddApplication();
            services.AddDomainCore();
            services.AddRepository(enviromentConfiguration);
            return services;
        }
    }
}
