using Hk.Application1.Core.Interfaces;
using Hk.Application1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hk.Services.Application1.Api
{
    [RoutePrefix("api/customerapi")]
    public class CustomerApiController : ApiController
    {
        #region "Members"
        ICustomerService _iCustomerService;
        #endregion

        #region "Constructor"
        /// <summary>
        /// Injecting depedencies
        /// </summary>
        /// <param name="iCustomerService"></param>
        public CustomerApiController(ICustomerService iCustomerService)
        {
            _iCustomerService = iCustomerService;
        }
        #endregion

        public void Delete(Customer entity)
        {
            _iCustomerService.Delete(entity);
        }

        public async Task DeleteAsync(int Id)
        {
            await _iCustomerService.DeleteAsync(Id);
        }

        public void DeleteMultiple(IEnumerable<Customer> entities)
        {
            _iCustomerService.DeleteMultiple(entities);
        }

        [Route("find/{predicate}")]
        [HttpGet]
        public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate)
        {
            return _iCustomerService.Find(predicate);
        }

        public Customer First(Expression<Func<Customer, bool>> where)
        {
            return _iCustomerService.First(where);
        }

        [Route("Get/{id}")]
        [HttpGet]
        public Customer Get(int id)
        {
            return _iCustomerService.Get(id);
        }

        [Route("GetAllCustomers")]
        [HttpGet]
        public IEnumerable<Customer> GetAll()
        {
            return _iCustomerService.GetAll();
        }

        [Route("GetAllCustomersAsync")]
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _iCustomerService.GetAllAsync();
        }

        [Route("GetAllByFilters/{includeProperties}")]
        [HttpGet]
        public IEnumerable<Customer> GetAllByFilters(params Expression<Func<Customer, object>>[] includeProperties)
        {
            return _iCustomerService.GetAllByFilters(includeProperties);
        }

        public IEnumerable<Customer> GetAllCustomerProducts(int customerId)
        {
            return _iCustomerService.GetAllCustomerProducts(customerId);
        }

        [Route("GetAsync/{id}")]
        [HttpGet]
        public async Task<Customer> GetAsync(int id)
        {
            return await _iCustomerService.GetAsync(id);
        }

        [Route("AddCustomer")]
        [HttpPost]
        public void Insert(Customer entity)
        {
            _iCustomerService.Insert(entity);
        }

        public void InsertMultiple(IEnumerable<Customer> entities)
        {
            _iCustomerService.InsertMultiple(entities);
        }

        public Customer Single(Expression<Func<Customer, bool>> where)
        {
            return _iCustomerService.Single(where);
        }

        public void Update(Customer entity)
        {
            _iCustomerService.Update(entity);
        }
    }
}
