using AutoMapper;
using Hk.Application1.Core.Models;
using Hk.Utilities.Interfaces;
using MultiProjectSample.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Web.Http;

namespace MultiProjectSample.Api
{
    [Authorize]
    [RoutePrefix("ProductApiWeb")]
    public class ProductApiController : BaseApiController
    {
        private IServiceManager _iServiceApiManager;

        public ProductApiController(ISerializer serializer, IServiceManager iServiceApiManager) : base(serializer)
        {
            _iServiceApiManager = iServiceApiManager;
        }

        [Route("ValidationRules")]
        [HttpGet]
        public HttpResponseMessage ValidationRules()
        {
            ProductModel productModel = new ProductModel();
            Dictionary<string, string> productValidationRules = productModel.GetValidationDefinition(typeof(ProductModel));
            var results = new { data = productModel, validationRules = productValidationRules };
            return OkResponse(results);
        }


        [Route("Find/{predicate}")]
        [HttpGet]
        public HttpResponseMessage Find(Expression<Func<Product, bool>> predicate)
        {
            return OkResponse(_iServiceApiManager.GetAsync<Product>("ProductApi", "Find", null));
        }

        [Route("Get/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            Dictionary<string, string> apiParams = new Dictionary<string, string>();
            apiParams.Add("id", id);
            Product productData = _iServiceApiManager.GetAsync<Product>("productapi", "Get", apiParams);
            ProductModel productModel = Mapper.Map<Product, ProductModel>(productData);
            return OkResponse(productModel);
        }


        [Route("GetAllProducts")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            //return OkResponse(_iApiManager.GetAsync<Product>("productapi", "GetAllProducts", null));
            IEnumerable<Product> productData = _iServiceApiManager.GetAsync<IEnumerable<Product>>("productapi", "GetAllProducts", null);
            return OkResponse(productData);
        }

        [Route("GetAllByFilters/{includeProperties}")]
        [HttpGet]
        public HttpResponseMessage GetAllByFilters(params Expression<Func<Product, object>>[] includeProperties)
        {
            Dictionary<string, string> apiParams = new Dictionary<string, string>();
            apiParams.Add("includeProperties", includeProperties.ToString());
            return OkResponse(_iServiceApiManager.GetAsync<Product>("productapi", "GetAllByFilters", apiParams));
        }

        [Route("GetProductsByCategory/{categoryId}")]
        [HttpGet]
        public HttpResponseMessage GetProductsByCategory(string categoryId)
        {
            Dictionary<string, string> apiParams = new Dictionary<string, string>();
            apiParams.Add("categoryId", categoryId);
            IEnumerable<Product> productData = _iServiceApiManager.GetAsync<IEnumerable<Product>>("productapi", "GetProductsByCategory", apiParams);
            return OkResponse(productData);
        }

        [Route("GetProductsBySupplier/{supplierId}")]
        [HttpGet]
        public HttpResponseMessage GetProductsBySupplier(string supplierId)
        {
            Dictionary<string, string> apiParams = new Dictionary<string, string>();
            apiParams.Add("categoryId", supplierId);
            return OkResponse(_iServiceApiManager.GetAsync<Product>("productapi", "GetProductsBySupplier", apiParams));
        }

        [Route("AddProduct")]
        [HttpPost]
        public bool Add(Product entity)
        {
            _iServiceApiManager.PostAsync<Product>("productapi", "Add", entity);
            return true;
        }
    }
}
