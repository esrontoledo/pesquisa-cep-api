using Dapper.FluentMap.Dommel.Mapping;
using Es.PesquisaCep.Domain.DbModel;

namespace Es.PesquisaCep.Infrastructure.DapperMaper
{
    public class UserDapperMap : DommelEntityMap<UserDbModel>
    {
        public UserDapperMap()
        {
            ToTable("Users");
            Map(u => u.Id).ToColumn("Id").IsKey().IsIdentity();
            Map(u => u.Username).ToColumn("Username");
            Map(u => u.Password).ToColumn("Password");
            Map(u => u.Role).ToColumn("Role");
        }
    }
}
