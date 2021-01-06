using Heat.Persistance.Context;
using Heat.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Heat.Persistance.Common
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Variables
        internal DbContext context;
        internal DbSet<TEntity> dbSet;
        #endregion

        #region Constructor
        public Repository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        #endregion

        #region Methods
        public async Task<bool> ExecuteProcedure(string name, params object[] parameters)
            => await this.context.Database.ExecuteSqlRawAsync(name, parameters) > 0;
        public async Task<IEnumerable<TEntity>> Get()
        {
            IQueryable<TEntity> query = dbSet;
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
        public async Task<TEntity> GetByID(object id)
        {
            return await dbSet.FindAsync(id);
        }
        public async Task Insert(TEntity entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                await this.context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task Delete(object id)
        {
            TEntity entityToDelete = await dbSet.FindAsync(id);
            await Delete(entityToDelete);
            await this.context.SaveChangesAsync();
        }
        public async Task Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            await this.context.SaveChangesAsync();
        }
        public async Task Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task DeleteAll(List<TEntity> entityToUpdate)
        {
            dbSet.RemoveRange(entityToUpdate);
            await context.SaveChangesAsync();
        }
        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }
        #endregion    
    }
}
