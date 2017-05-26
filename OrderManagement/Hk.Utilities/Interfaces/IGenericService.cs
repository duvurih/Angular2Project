using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hk.Utilities.Interfaces
{
    public interface IGenericService<DEntity> where DEntity : class
    {
        DEntity Get(int id);
        Task<DEntity> GetAsync(int id);

        IEnumerable<DEntity> GetAll();
        Task<IEnumerable<DEntity>> GetAllAsync();

        IEnumerable<DEntity> Find(Expression<Func<DEntity, bool>> predicate);

        IEnumerable<DEntity> GetAllByFilters(params Expression<Func<DEntity, object>>[] includeProperties);

        DEntity Single(Expression<Func<DEntity, bool>> where);
        DEntity First(Expression<Func<DEntity, bool>> where);

        DEntity Insert(DEntity entity);
        void InsertMultiple(IEnumerable<DEntity> entities);

        void Delete(DEntity entity);
        void DeleteMultiple(IEnumerable<DEntity> entities);
        Task DeleteAsync(int Id);

        void Update(DEntity entity);
    }
}
