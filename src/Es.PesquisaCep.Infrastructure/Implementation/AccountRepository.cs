using Dapper;
using Es.PesquisaCep.Domain.DbModel;
using Es.PesquisaCep.Domain.Repositories.Interfaces;
using Es.PesquisaCep.DomainCore.Interfaces;
using Es.PesquisaCep.Infrastructure.Implementation.Base;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Es.PesquisaCep.Infrastructure.Implementation
{
    public class AccountRepository : BaseRepository<UserDbModel>, IAccountRepository
    {
        public AccountRepository(Lazy<SqlConnection> connectionString, IEnviromentConfiguration enviromentConfiguration)
            : base(connectionString, enviromentConfiguration)
        { }

        public async Task<UserDbModel> LoginAsync(string username, string password)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@user_name", username, DbType.AnsiString, size: 30);
            parameters.Add("@password", password, DbType.AnsiString, size: 10);

            var query = @"SELECT * FROM Users u WHERE u.Username = @user_name AND u.Password = @password";

            using IDbConnection conection = base.Conection().Value;
            return await conection.QueryFirstAsync<UserDbModel>(query, parameters);
        }
    }
}
