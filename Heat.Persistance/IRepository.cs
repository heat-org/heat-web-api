using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Heat.Persistance
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<bool> ExecuteProcedure(string name, params object[] parameters);
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
                                       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                       string includeProperties = "");
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> GetByID(object id);
        Task Insert(TEntity entity);
        Task Delete(object id);
        Task DeleteAll(List<TEntity> entityToUpdate);
        Task Update(TEntity entityToUpdate);
        Task SaveChanges();
    }
}