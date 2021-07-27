using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;

namespace Es.PesquisaCep.Infrastructure.DapperMaper.Register
{
    public class RegisterMapTable
    {
        public static void Register()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new UserDapperMap());
                config.ForDommel();
            });
        }
    }
}
