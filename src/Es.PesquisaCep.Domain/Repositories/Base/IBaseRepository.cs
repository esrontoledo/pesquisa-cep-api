using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Es.PesquisaCep.Domain.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Lazy<SqlConnection> Conection();
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> DeleteAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task InsertAsync(TEntity entity);
    }
}
