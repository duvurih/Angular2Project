using Hk.Application1.Core.Interfaces;
using Hk.Application1.Core.Models;
using Hk.Application1.Repository.Interface;
using Hk.Application1.Repository.Repositories;
using Hk.Utilities.GenericComponents;
using Hk.Utilities.Interfaces;
using System;
using System.Collections.Generic;

namespace Hk.Application1.Core.ModelsHk.Application1.Services.Products
{
    public class ProductService : GenericService<Product>, IProductService
    {
        IProductRepository _iProductRepository;
        IUnitOfWork _unitOfWork;
        IServiceManager _iServiceManager;
        //IPublisherService<SMSInformation> _iPublisherService;

        public ProductService(
            IProductRepository iProductRepository,
            IUnitOfWork unitOfWork,
            IServiceManager iServiceManager
            //IPublisherService<SMSInformation> iPublisherService
            )
            : base(iProductRepository)
        {
            _iProductRepository = iProductRepository;
            _unitOfWork = unitOfWork;
            _iServiceManager = iServiceManager;
            //_iPublisherService = iPublisherService;
        }

        public override void Insert(Product entity)
        {
            var repository = _unitOfWork.GetRepository<ProductRepository, Product>();
            repository.Insert(entity);
            //SMSInformation smsInfo = new SMSInformation();
            //var smsComponent = new SmsConnectorEventService<SMSInformation>(_iApiManager, _iPublisherService);
            //var emailComponent = new eMailConnectorEventService<SMSInformation>(_iApiManager, _iPublisherService);
            //_iPublisherService.DataPublisher += smsComponent.OnDataPublisher;
            //_iPublisherService.DataPublisher += emailComponent.OnDataPublisher;

            _unitOfWork.SaveChanges();
            //_unitOfWork.Commit();
        }

        public override void InsertMultiple(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public override void Update(Product entity)
        {
            var repository = _unitOfWork.GetRepository<ProductRepository, Product>();
            repository.Update(entity);
            _unitOfWork.SaveChanges();
            //_unitOfWork.Commit();
        }

        public override void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public override void DeleteMultiple(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return _iProductRepository.GetProductsByCategory(categoryId);
        }

        public IEnumerable<Product> GetProductsBySupplier(int supplierId)
        {
            return _iProductRepository.GetProductsBySupplier(supplierId);
        }


    }
}
