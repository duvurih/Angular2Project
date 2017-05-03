using Hk.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hk.Utilities.GenericComponents
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        #region "Members"
        IRepository<TEntity> _iRepository;
        #endregion

        #region "Constructor"
        /// <summary>
        /// Generic Service constructor injectoring repository
        /// </summary>
        /// <param name="iRepository">Injecting Repository</param>
        public GenericService(IRepository<TEntity> iRepository)
        {
            _iRepository = iRepository;
        }
        #endregion

        #region "Insert Methods"
        /// <summary>
        /// Inserting new reord
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserting multiple records
        /// </summary>
        /// <param name="entities"></param>
        public virtual void InsertMultiple(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region "Update Methods"
        /// <summary>
        /// Updating records
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region "Search Methods"
        /// <summary>
        /// Find results based on criteria
        /// </summary>
        /// <param name="predicate">criteria</param>
        /// <returns>Returns results</returns>
        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _iRepository.Find(predicate);
        }
        #endregion

        #region "Get Methods"
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
        #endregion

        #region "Delete Methods"
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
        #endregion

        #region "Search Methods"
        public TEntity Single(Expression<Func<TEntity, bool>> where)
        {
            return _iRepository.Single(where);
        }

        public TEntity First(Expression<Func<TEntity, bool>> where)
        {
            return _iRepository.First(where);
        }
        #endregion
    }
}
