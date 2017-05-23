using AutoMapper;
using Hk.Application1.Core.Models;
using Hk.Utilities.Interfaces;
using MultiProjectSample.Models.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace MultiProjectSample.Api
{
    [Authorize]
    [RoutePrefix("CustomerApiWeb")]
    public class CustomerApiController : BaseApiController
    {
        private IServiceManager _iServiceApiManager;

        public CustomerApiController(ISerializer serializer, IServiceManager iServiceApiManager) : base(serializer)
        {
            _iServiceApiManager = iServiceApiManager;
        }

        [Route("ValidationRules")]
        [HttpGet]
        public HttpResponseMessage ValidationRules()
        {
            CustomerModel customerModel = new CustomerModel();
            Dictionary<string, string> customerValidationRules = customerModel.GetValidationDefinition(typeof(CustomerModel));
            var results = new { data = customerModel, validationRules = customerValidationRules };
            return OkResponse(results);
        }

        [Route("Get/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            Dictionary<string, string> apiParams = new Dictionary<string, string>();
            apiParams.Add("id", id);
            Customer customerData = _iServiceApiManager.GetAsync<Customer>("customerapi", "Get", apiParams);
            CustomerModel customerModel = Mapper.Map<Customer, CustomerModel>(customerData);
            return OkResponse(customerModel);
        }


        [Route("GetAllCustomers")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            IEnumerable<Customer> customerData = _iServiceApiManager.GetAsync<IEnumerable<Customer>>("customerapi", "GetAllCustomers", null);
            return OkResponse(customerData);
        }
    }
}
