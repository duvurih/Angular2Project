using Hk.Application1.Core.Interfaces;
using Hk.Application1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hk.Services.Application1.Api
{
    [RoutePrefix("api/orderapi")]
    public class OrderApiController : ApiController
    {
        #region "Members"
        IOrderService _iOrderService;
        #endregion

        #region "Constructor"
        /// <summary>
        /// Constructor injecting product service
        /// </summary>
        /// <param name="iOrderService"></param>
        public OrderApiController(IOrderService iOrderService)
        {
            _iOrderService = iOrderService;
        }

        [Route("DeleteOrder")]
        [HttpPost]
        public bool Delete(Order entity)
        {
            _iOrderService.Delete(entity);
            return true;
        }

        public Task DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteMultiple(IEnumerable<Order> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> Find(Expression<Func<Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Order First(Expression<Func<Order, bool>> where)
        {
            throw new NotImplementedException();
        }

        [Route("Get/{id}")]
        [HttpGet]
        public Order Get(int id)
        {
            return _iOrderService.Get(id);
        }

        [Route("GetAllOrders")]
        [HttpGet]
        public IEnumerable<Order> GetAll()
        {
            return _iOrderService.GetAll();
        }

        [Route("GetAllOrdersAsync")]
        [HttpGet]
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _iOrderService.GetAllAsync();
        }

        public IEnumerable<Order> GetAllByFilters(params Expression<Func<Order, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        [Route("GetAsync/{id}")]
        [HttpGet]
        public async Task<Order> GetAsync(int id)
        {
            return await _iOrderService.GetAsync(id);
        }

        public IEnumerable<Order_Detail> GetOrderDetailByOrderId(int orderId)
        {
            return _iOrderService.GetOrderDetailByOrderId(orderId);
        }

        public IEnumerable<Order> GetOrdersByCustomerId(string customerId)
        {
            return _iOrderService.GetOrdersByCustomerId(customerId);
        }

        [Route("AddOrder")]
        [HttpPost]
        public Order Insert(Order entity)
        {
            return _iOrderService.Insert(entity);
        }

        public void InsertMultiple(IEnumerable<Order> entities)
        {
            throw new NotImplementedException();
        }

        public Order Single(Expression<Func<Order, bool>> where)
        {
            throw new NotImplementedException();
        }

        [Route("UpdateOrder")]
        [HttpPost]
        public bool Update(Order entity)
        {
            _iOrderService.Update(entity);
            return true;
        }
        #endregion
    }
}
