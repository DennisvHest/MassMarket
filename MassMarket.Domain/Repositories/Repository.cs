using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MassMarket.Domain.Repositories {

    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class {

        protected readonly DbContext Context;

	    protected Repository(DbContext context) {
            Context = context;
        }

        public async Task<TEntity> Get(int id) {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> GetAll() {
            return Context.Set<TEntity>();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) {
            return Context.Set<TEntity>().Where(predicate);
        }

        public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate) {
            return await Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate) {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public void Add(TEntity entity) {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities) {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity) {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities) {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}