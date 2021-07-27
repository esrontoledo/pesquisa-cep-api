using Es.PesquisaCep.Domain.Repositories.Interfaces;
using Es.PesquisaCep.DomainCore.Constantes;
using Es.PesquisaCep.DomainCore.Interfaces;
using Es.PesquisaCep.Infrastructure.DapperMaper.Register;
using Es.PesquisaCep.Infrastructure.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Data.SqlClient;
using Polly;
using Polly.Extensions.Http;
using System.Net.Http;

namespace Es.PesquisaCep.Infrastructure
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IEnviromentConfiguration enviromentConfiguration)
        {
            services.TryAddScoped<IAccountRepository, AccountRepository>();
            services.TryAddScoped<ICepRepository, CepRepository>();
            services.AddClientInfrastructure(enviromentConfiguration);
            services.AddConnectionString(enviromentConfiguration);
            RegisterMapTable.Register();
            return services;
        }

        static IServiceCollection AddConnectionString(this IServiceCollection services, IEnviromentConfiguration enviromentConfiguration)
        {
            services.AddScoped(scope =>
            {
                return new Lazy<SqlConnection>(() =>
                {
                    var connection = new SqlConnection(enviromentConfiguration.ConnectionString);
                    connection.Open();
                    return connection;
                });
            });

            return services;
        }

        static IServiceCollection AddClientInfrastructure(this IServiceCollection services, IEnviromentConfiguration enviromentConfiguration)
        {
            services.AddHttpClient(ParametroSistema.AmbienteCep, c => 
            { 
                c.BaseAddress = new Uri(enviromentConfiguration.CepUrl); 
            }).AddPolicyHandler(GetRetryPolicy());

            return services;
        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(p => !p.IsSuccessStatusCode)
                .WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(0.5, retryAttempt)));
        }
    }
}
