using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hk.Utilities.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        Task<TEntity> GetAsync(int id);

        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAllByFilters(params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity Single(Expression<Func<TEntity, bool>> where);
        TEntity First(Expression<Func<TEntity, bool>> where);

        void Insert(TEntity entity);
        void InsertMultiple(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);
        void DeleteMultiple(IEnumerable<TEntity> entities);
        Task DeleteAsync(int Id);

        void Update(TEntity entity);

        //Task<int> SaveChanges();
        //Task SaveChangesAsync();
    }
}
