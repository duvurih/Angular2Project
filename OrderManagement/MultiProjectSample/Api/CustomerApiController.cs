using AutoMapper;
using Hk.Application1.Core.Models;
using Hk.Utilities.Interfaces;
using MultiProjectSample.Models.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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

            BaseAddressModel baseAddressModel = new BaseAddressModel();
            Dictionary<string, string> addressValidationRules = baseAddressModel.GetValidationDefinition(typeof(BaseAddressModel));
            customerValidationRules = customerValidationRules.Concat(addressValidationRules).ToDictionary(x => x.Key, x => x.Value);

            BaseCommunicationModel baseCommunicationModel = new BaseCommunicationModel();
            Dictionary<string, string> communicationValidationRules = baseAddressModel.GetValidationDefinition(typeof(BaseCommunicationModel));
            customerValidationRules = customerValidationRules.Concat(communicationValidationRules).ToDictionary(x => x.Key, x => x.Value);

            var results = new { data = customerModel, validationRules = customerValidationRules };
            return OkResponse(results);
        }

        [Route("GetCustomerById/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            Dictionary<string, string> apiParams = new Dictionary<string, string>();
            apiParams.Add("id", id);
            Customer customerData = _iServiceApiManager.GetAsync<Customer>("customerapi", "GetCustomerById", apiParams);
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

        [Route("AddCustomer")]
        [HttpPost]
        public HttpResponseMessage Add(CustomerModel entity)
        {
            Customer customerData = Mapper.Map<CustomerModel, Customer>(entity);
            Customer response = _iServiceApiManager.PostAsync<Customer>("customerapi", "AddCustomer", customerData);
            CustomerModel customerDataResponse = Mapper.Map<Customer, CustomerModel>(response);
            return OkResponse(customerDataResponse);
        }

        [Route("UpdateCustomer")]
        [HttpPost]
        public HttpResponseMessage UpdateCustomer(CustomerModel entity)
        {
            Customer customerData = Mapper.Map<CustomerModel, Customer>(entity);
            bool response = _iServiceApiManager.PostAsync<bool>("customerapi", "UpdateCustomer", customerData);
            return OkResponse(response);
        }

        [Route("DeleteCustomer")]
        [HttpPost]
        public HttpResponseMessage DeleteCustomer(CustomerModel entity)
        {
            Customer customerData = Mapper.Map<CustomerModel, Customer>(entity);
            bool response = _iServiceApiManager.PostAsync<bool>("customerapi", "DeleteCustomer", customerData);
            return OkResponse(response);
        }

        [HttpPost]
        [Route("SearchCustomer")]
        public async Task<HttpResponseMessage> SearchCustomer([FromBody] string searchPhrase)
        {
            HttpResponseMessage response = null;
            await Task.Run(() =>
            {
                Dictionary<string, string> apiParams = new Dictionary<string, string>();
                apiParams.Add("search", searchPhrase);

                IEnumerable<Customer> customerData = _iServiceApiManager.GetAsync<IEnumerable<Customer>>("customerapi", "SearchCustomer", apiParams);
                response = OkResponse(customerData);
            });
            return response;
        }
    }
}
