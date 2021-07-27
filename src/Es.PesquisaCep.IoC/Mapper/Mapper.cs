using AutoMapper;
using Es.PesquisaCep.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace Es.PesquisaCep.IoC.Mapper
{
    public static class Mapper
    {
        public static IServiceCollection ConfigureMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserMap());
                mc.AddProfile(new CepMap());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
