using Hk.Application1.Core.Interfaces;
using Hk.Application1.Core.Models;
using Hk.Application1.Repository.Interface;
using Hk.Application1.Repository.Repositories;
using Hk.Utilities.GenericComponents;
using Hk.Utilities.Interfaces;
using System;
using System.Collections.Generic;

namespace Hk.Application1.Services.Suppliers
{
    public class SupplierService : GenericService<Supplier>, ISupplierService
    {
        ISupplierRepository _iSupplierRepository;
        IUnitOfWork _unitOfWork;
        IServiceManager _iServiceManager;

        public SupplierService(
            ISupplierRepository iSupplierRepository,
            IUnitOfWork unitOfWork,
            IServiceManager iServiceManager
            //IRepository<Supplier> iRepository
            ) : base(iSupplierRepository)
        {
            _iSupplierRepository = iSupplierRepository;
            _unitOfWork = unitOfWork;
            _iServiceManager = iServiceManager;
        }

        public IEnumerable<Supplier> GetAllSupplierProducts(int supplierId)
        {
            throw new NotImplementedException();
        }

        public override Supplier Insert(Supplier entity)
        {
            var repository = _unitOfWork.GetRepository<SupplierRepository, Supplier>();
            repository.Insert(entity);
            _unitOfWork.SaveChanges();
            return entity;
        }

        public override void InsertMultiple(IEnumerable<Supplier> entities)
        {
            throw new NotImplementedException();
        }

        public override void Update(Supplier entity)
        {
            var repository = _unitOfWork.GetRepository<SupplierRepository, Supplier>();
            repository.Update(entity);
            _unitOfWork.SaveChanges();
        }

        public override void Delete(Supplier entity)
        {
            var repository = _unitOfWork.GetRepository<SupplierRepository, Supplier>();
            repository.Delete(entity);
            _unitOfWork.SaveChanges();
        }

        public override void DeleteMultiple(IEnumerable<Supplier> entities)
        {
            throw new NotImplementedException();
        }
    }
}
