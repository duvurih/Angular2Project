using Hk.Application1.Data.Models;
using Hk.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hk.Application1.Repository.GenericRepository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DatabaseContext _context;

        //Entiry Framework Performance Tips
        //https://www.simple-talk.com/dotnet/net-tools/entity-framework-performance-and-what-you-can-do-about-it/

        public Repository(DatabaseContext context)
        {
            _context = context;
        }

        public void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void InsertMultiple(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached || entry.State == EntityState.Modified)
            {
                _context.Set<TEntity>().Attach(entity);
                entry.State = EntityState.Modified;
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }


        public IEnumerable<TEntity> GetAllByFilters(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            //EF uses a Lazy Loading strategy, where it doesnot fetch any data associated
            //with the employees on the Companies object when the first query is run.
            //When you try to access the Companies, it will subsequently retrieves the 
            //employees information regardless of whether it is needed or not. 
            //This is called as "N+1 select problem".

            //Eager Loading data access strategy, 
            //which fetches related data in a single query when you use a Include() in single statement
            IQueryable<TEntity> query = _context.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void DeleteMultiple(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public async Task DeleteAsync(int Id)
        {
            TEntity entity = await GetAsync(Id);
            _context.Set<TEntity>().Remove(entity);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> where)
        {
            return _context.Set<TEntity>().SingleOrDefault<TEntity>(where);
        }

        public TEntity First(Expression<Func<TEntity, bool>> where)
        {
            return _context.Set<TEntity>().First<TEntity>(where);
        }
    }
}
