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
    [RoutePrefix("SupplierApiWeb")]

    public class SupplierApiController : BaseApiController
    {
        private IServiceManager _iServiceApiManager;

        public SupplierApiController(ISerializer serializer, IServiceManager iServiceApiManager) : base(serializer)
        {
            _iServiceApiManager = iServiceApiManager;
        }

        [Route("ValidationRules")]
        [HttpGet]
        public HttpResponseMessage ValidationRules()
        {
            SupplierModel supplierModel = new SupplierModel();
            Dictionary<string, string> supplierValidationRules = supplierModel.GetValidationDefinition(typeof(SupplierModel));
            var results = new { data = supplierModel, validationRules = supplierValidationRules };
            return OkResponse(results);
        }

        [Route("Get/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            Dictionary<string, string> apiParams = new Dictionary<string, string>();
            apiParams.Add("id", id);
            Supplier supplierData = _iServiceApiManager.GetAsync<Supplier>("supplierapi", "Get", apiParams);
            SupplierModel supplierModel = Mapper.Map<Supplier, SupplierModel>(supplierData);
            return OkResponse(supplierModel);
        }

        [Route("GetAllSuppliers")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            IEnumerable<Supplier> supplierData = _iServiceApiManager.GetAsync<IEnumerable<Supplier>>("supplierapi", "GetAllSuppliers", null);
            return OkResponse(supplierData);
        }

        [Route("AddSupplier")]
        [HttpPost]
        public HttpResponseMessage Add(SupplierModel entity)
        {
            Supplier supplierData = Mapper.Map<SupplierModel, Supplier>(entity);
            Supplier response = _iServiceApiManager.PostAsync<Supplier>("supplierapi", "AddSupplier", supplierData);
            SupplierModel supplierDataResponse = Mapper.Map<Supplier, SupplierModel>(response);
            return OkResponse(supplierDataResponse);
        }

        [Route("UpdateSupplier")]
        [HttpPost]
        public HttpResponseMessage UpdateSupplier(SupplierModel entity)
        {
            Supplier supplierData = Mapper.Map<SupplierModel, Supplier>(entity);
            bool response = _iServiceApiManager.PostAsync<bool>("supplierapi", "UpdateSupplier", supplierData);
            return OkResponse(response);
        }

        [Route("DeleteSupplier")]
        [HttpPost]
        public HttpResponseMessage DeleteSupplier(SupplierModel entity)
        {
            Supplier supplierData = Mapper.Map<SupplierModel, Supplier>(entity);
            bool response = _iServiceApiManager.PostAsync<bool>("supplierapi", "DeleteSupplier", supplierData);
            return OkResponse(response);
        }
    }
}
