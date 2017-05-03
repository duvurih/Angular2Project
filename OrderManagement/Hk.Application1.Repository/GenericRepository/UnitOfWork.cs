using Hk.Application1.Data.Models;
using Hk.Application1.Repository.Interface;
using Hk.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hk.Application1.Repository.GenericRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _dbContext;

        public UnitOfWork(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        protected Dictionary<Type, object> RepositoryMap = new Dictionary<Type, object>();

        public IRepository<TObject> GetRepository<TRepository, TObject>() where TRepository : class where TObject : class
        {

            var type = typeof(TRepository);
            var repository = Activator.CreateInstance(type, this._dbContext);
            return repository as Repository<TObject>;
            //var repository = (Repository<TObject>)Activator.CreateInstance(type, this._dbContext);
            //if (repository != null)
            //{
            //    return repository;
            //}
            //return null;
        }

        //public DatabaseContext DbContext
        //{
        //    get { return dbContext ?? (dbContext = dbFactory.Init()); }
        //}

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        //public void Commit()
        //{
        //    _dbContext.Commit();
        //}

        public void Rollback()
        {
            _dbContext
                .ChangeTracker
                .Entries()
                .ToList()
                .ForEach(x => x.Reload());
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
