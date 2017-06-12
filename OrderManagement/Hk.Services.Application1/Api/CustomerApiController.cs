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

        [Route("DeleteCustomer")]
        [HttpPost]
        public bool Delete(Customer entity)
        {
            _iCustomerService.Delete(entity);
            return true;
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

        [Route("GetCustomerById/{id}")]
        [HttpGet]
        public Customer GetCustomerById(string id)
        {
            return _iCustomerService.GetCustomerById(id);
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

        public IEnumerable<Customer> GetAllCustomerProducts(string customerId)
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
        public Customer Insert(Customer entity)
        {
            return _iCustomerService.Insert(entity);
        }

        public void InsertMultiple(IEnumerable<Customer> entities)
        {
            _iCustomerService.InsertMultiple(entities);
        }

        public Customer Single(Expression<Func<Customer, bool>> where)
        {
            return _iCustomerService.Single(where);
        }

        [Route("UpdateCustomer")]
        [HttpPost]
        public bool Update(Customer entity)
        {
            _iCustomerService.Update(entity);
            return true;
        }

        [Route("SearchCustomer/{searchPhrase}")]
        [HttpGet]
        public async Task<IEnumerable<Customer>> SearchCustomer(string searchPhrase)
        {
            IEnumerable<Customer> customers = null;
            await Task.Run(() =>
            {
                // string customerName = searchPhrase.ToString();
                customers = _iCustomerService.Find(x => x.CompanyName.Contains(searchPhrase));
                return customers;

            });
            return customers;
        }
    }
}
