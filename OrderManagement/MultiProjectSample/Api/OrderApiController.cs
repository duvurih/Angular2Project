using AutoMapper;
using Hk.Application1.Core.Models;
using Hk.Utilities.Interfaces;
using MultiProjectSample.Models.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MultiProjectSample.Api
{
    [Authorize]
    [RoutePrefix("OrderApiWeb")]
    public class OrderApiController : BaseApiController
    {
        private IServiceManager _iServiceApiManager;

        public OrderApiController(ISerializer serializer, IServiceManager iServiceApiManager) : base(serializer)
        {
            _iServiceApiManager = iServiceApiManager;
        }

        [Route("OrderValidationRules")]
        [HttpGet]
        public HttpResponseMessage OrderValidationRules()
        {
            OrderModel orderModel = new OrderModel();
            Dictionary<string, string> orderValidationRules = orderModel.GetValidationDefinition(typeof(OrderModel));

            var results = new { data = orderModel, validationRules = orderValidationRules };
            return OkResponse(results);
        }

        [Route("OrderDetailValidationRules")]
        [HttpGet]
        public HttpResponseMessage OrderDetailValidationRules()
        {
            OrderDetailsModel orderDetailsModel = new OrderDetailsModel();
            Dictionary<string, string> orderDetailsValidationRules = orderDetailsModel.GetValidationDefinition(typeof(OrderDetailsModel));

            var results = new { data = orderDetailsModel, validationRules = orderDetailsValidationRules };
            return OkResponse(results);
        }


        [Route("Get/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            Dictionary<string, string> apiParams = new Dictionary<string, string>();
            apiParams.Add("id", id);
            Order orderData = _iServiceApiManager.GetAsync<Order>("orderapi", "Get", apiParams);
            OrderModel orderModel = Mapper.Map<Order, OrderModel>(orderData);
            return OkResponse(orderModel);
        }

        [Route("GetAllOrders")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            IEnumerable<Order> orderData = _iServiceApiManager.GetAsync<IEnumerable<Order>>("orderapi", "GetAllOrders", null);
            return OkResponse(orderData);
        }

        public Task<IEnumerable<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order_Detail> GetOrderDetailByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrdersByCustomerId(string customerId)
        {
            throw new NotImplementedException();
        }

        public Order Insert(Order entity)
        {
            throw new NotImplementedException();
        }


        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
