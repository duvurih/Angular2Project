using Hk.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hk.Utilities.GenericComponents
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        IRepository<TEntity> _iRepository;

        public GenericService(IRepository<TEntity> iRepository)
        {
            _iRepository = iRepository;
        }

        public virtual void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void InsertMultiple(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _iRepository.Find(predicate);
        }

        public virtual TEntity Get(int id)
        {
            return _iRepository.Get(id);
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _iRepository.GetAsync(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _iRepository.GetAll();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _iRepository.GetAllAsync();
        }

        public virtual IEnumerable<TEntity> GetAllByFilters(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _iRepository.GetAllByFilters(includeProperties);
        }


        public virtual void Delete(TEntity entity)
        {
            _iRepository.Delete(entity);
        }

        public virtual void DeleteMultiple(IEnumerable<TEntity> entities)
        {
            _iRepository.DeleteMultiple(entities);
        }

        public async virtual Task DeleteAsync(int Id)
        {
            await _iRepository.DeleteAsync(Id);
            //await _iRepository.SaveChangesAsync();
        }

        public TEntity Single(Expression<Func<TEntity, bool>> where)
        {
            return _iRepository.Single(where);
        }

        public TEntity First(Expression<Func<TEntity, bool>> where)
        {
            return _iRepository.First(where);
        }
    }
}
