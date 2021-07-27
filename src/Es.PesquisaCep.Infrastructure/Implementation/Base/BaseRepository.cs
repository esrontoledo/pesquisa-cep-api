using Dommel;
using Es.PesquisaCep.Domain.Repositories.Base;
using Es.PesquisaCep.DomainCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Es.PesquisaCep.Infrastructure.Implementation.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly Lazy<SqlConnection> _connectionString;
        private readonly IEnviromentConfiguration _enviromentConfiguration;

        public BaseRepository(Lazy<SqlConnection> connectionString, IEnviromentConfiguration enviromentConfiguration)
        {
            _connectionString = connectionString;
            _enviromentConfiguration = enviromentConfiguration;
        }

        public virtual Lazy<SqlConnection> Conection()
        {
            if (_connectionString.Value != null && !string.IsNullOrWhiteSpace(_connectionString.Value.ConnectionString)) return _connectionString;

            return new Lazy<SqlConnection>(() =>
            {
                var conexao = new SqlConnection(_enviromentConfiguration.ConnectionString);
                conexao.Open();
                return conexao;
            });
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            using IDbConnection conn = Conection().Value;
            return await conn.UpdateAsync(entity);
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            using IDbConnection conn = Conection().Value;
            using IDbTransaction tran = conn.BeginTransaction();

            try
            {
                await conn.InsertAsync(entity, tran);
                tran.Commit();
            }
            catch (Exception)
            {
                tran.Rollback();
                throw;
            }
        }

        public virtual async Task<bool> DeleteAsync(TEntity entity)
        {
            using IDbConnection conn = Conection().Value;
            return await conn.DeleteAsync(entity);
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            using IDbConnection conn = Conection().Value;
            return await conn.GetAsync<TEntity>(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            using IDbConnection conn = Conection().Value;
            return await conn.GetAsync<TEntity>(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using IDbConnection conn = Conection().Value;
            return await conn.SelectAsync(predicate);
        }
    }
}
