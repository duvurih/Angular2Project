using Hk.Application1.Core.Interfaces;
using Hk.Application1.Core.Models;
using Hk.Application1.Repository.Interface;
using Hk.Application1.Repository.Repositories;
using Hk.Utilities.GenericComponents;
using Hk.Utilities.Interfaces;
using System;
using System.Collections.Generic;

namespace Hk.Application1.Services.Orders
{
    public class OrderService : GenericService<Order>, IOrderService
    {
        IOrderRepository _iOrderRepository;
        IUnitOfWork _unitOfWork;
        IServiceManager _iServiceManager;

        public OrderService(
            IOrderRepository iOrderRepository,
            IUnitOfWork unitOfWork,
            IServiceManager iServiceManager
            ) : base(iOrderRepository)
        {
            _iOrderRepository = iOrderRepository;
            _unitOfWork = unitOfWork;
            _iServiceManager = iServiceManager;
        }

        public IEnumerable<Order_Detail> GetOrderDetailByOrderId(int orderId)
        {
            return _iOrderRepository.GetOrderDetailByOrderId(orderId);
        }

        public IEnumerable<Order> GetOrdersByCustomerId(string customerId)
        {
            return _iOrderRepository.GetOrdersByCustomerId(customerId);
        }

        public override Order Insert(Order entity)
        {
            var repository = _unitOfWork.GetRepository<OrderRepository, Order>();
            repository.Insert(entity);
            //SMSInformation smsInfo = new SMSInformation();
            //var smsComponent = new SmsConnectorEventService<SMSInformation>(_iApiManager, _iPublisherService);
            //var emailComponent = new eMailConnectorEventService<SMSInformation>(_iApiManager, _iPublisherService);
            //_iPublisherService.DataPublisher += smsComponent.OnDataPublisher;
            //_iPublisherService.DataPublisher += emailComponent.OnDataPublisher;

            _unitOfWork.SaveChanges();
            //_unitOfWork.Commit();
            return entity;
        }

        public override void InsertMultiple(IEnumerable<Order> entities)
        {
            throw new NotImplementedException();
        }

        public override void Update(Order entity)
        {
            var repository = _unitOfWork.GetRepository<OrderRepository, Order>();
            repository.Update(entity);
            _unitOfWork.SaveChanges();
            //_unitOfWork.Commit();
        }

        public override void Delete(Order entity)
        {
            var repository = _unitOfWork.GetRepository<OrderRepository, Order>();
            repository.Delete(entity);
            _unitOfWork.SaveChanges();
        }

        public override void DeleteMultiple(IEnumerable<Order> entities)
        {
            throw new NotImplementedException();
        }
    }
}
