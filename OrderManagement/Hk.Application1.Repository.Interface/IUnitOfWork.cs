using Hk.Utilities.Interfaces;
using System;
using System.Threading.Tasks;

namespace Hk.Application1.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        //IRepository<T> GetRepository<T>() where T : class;
        IRepository<TObject> GetRepository<TRepository, TObject>() where TRepository : class where TObject : class;

        int SaveChanges();
        Task SaveChangesAsync();

        //void Commit();
        void Rollback();
    }
}
