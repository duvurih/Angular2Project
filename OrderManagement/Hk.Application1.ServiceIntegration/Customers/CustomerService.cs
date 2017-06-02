using Hk.Application1.Core.Interfaces;
using Hk.Application1.Core.Models;
using Hk.Application1.Repository.Interface;
using Hk.Application1.Repository.Repositories;
using Hk.Utilities.GenericComponents;
using Hk.Utilities.Interfaces;
using System;
using System.Collections.Generic;

namespace Hk.Application1.Services.Customers
{
    public class CustomerService : GenericService<Customer>, ICustomerService
    {
        ICustomerRepository _iCustomerRepository;
        IUnitOfWork _unitOfWork;
        IServiceManager _iServiceManager;

        public CustomerService(
            ICustomerRepository iCustomerRepository,
            IUnitOfWork unitOfWork,
            IServiceManager iServiceManager
            //IRepository<Customer> iRepository
            ) : base(iCustomerRepository)
        {
            _iCustomerRepository = iCustomerRepository;
            _unitOfWork = unitOfWork;
            _iServiceManager = iServiceManager;
        }

        public IEnumerable<Customer> GetAllCustomerProducts(int customerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAllCustomerProducts(string customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(string customerId)
        {
            return _iCustomerRepository.GetCustomerById(customerId);
        }


        public override Customer Insert(Customer entity)
        {
            var repository = _unitOfWork.GetRepository<CustomerRepository, Customer>();
            repository.Insert(entity);
            _unitOfWork.SaveChanges();
            return entity;
        }

        public override void InsertMultiple(IEnumerable<Customer> entities)
        {
            throw new NotImplementedException();
        }

        public override void Update(Customer entity)
        {
            var repository = _unitOfWork.GetRepository<CustomerRepository, Customer>();
            repository.Update(entity);
            _unitOfWork.SaveChanges();
        }

        public override void Delete(Customer entity)
        {
            var repository = _unitOfWork.GetRepository<CustomerRepository, Customer>();
            repository.Delete(entity);
            _unitOfWork.SaveChanges();
        }

        public override void DeleteMultiple(IEnumerable<Customer> entities)
        {
            throw new NotImplementedException();
        }
    }
}
