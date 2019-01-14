using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace task1_3.Repositories
{
    public class Repository<TEntity, Tcontext> : IRepository<TEntity> where TEntity : class
        where Tcontext: DbContext
    {
        protected readonly Tcontext Context;
        
        public Repository(Tcontext context)
        {
            Context = context;
        }
        
        public TEntity Get(int id)
        {            
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {           
            return Context.Set<TEntity>().ToList();
        }
       
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
