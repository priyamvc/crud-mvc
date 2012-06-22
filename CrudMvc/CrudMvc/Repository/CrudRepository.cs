using System.Collections.Generic;
using System.Data;
using System.Data.Entity;

namespace CrudMvc.Repository {
    public class CrudRepository<TEntity> where TEntity : class {
        protected DbContext Context;
        public CrudRepository(DbContext context) {
            Context = context;
        }

        public TEntity Get(object id) {
            return Set.Find(id);
        }

        public IEnumerable<TEntity> GetAll() {
            return Set;
        }

        public TEntity Create(TEntity entity) {
            Set.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public TEntity Edit(TEntity entity) {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }

        public TEntity Delete(object id) {
            TEntity entity = Get(id);
            return Delete(entity);
        }

        public TEntity Delete(TEntity entity) {
            Set.Remove(entity);
            Context.SaveChanges();
            return entity;
        }

        protected DbSet<TEntity> Set {
            get { return Context.Set<TEntity>(); }
        }
    }
}