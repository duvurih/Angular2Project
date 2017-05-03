using Hk.Application1.Core.Models;
using Hk.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Web.Http;

namespace MultiProjectSample.Api
{
    [RoutePrefix("ProductApiWeb")]
    public class ProductApiController : BaseApiController
    {
        private IApiManager _iApiManager;

        public ProductApiController(ISerializer serializer, IApiManager iApiManager) : base(serializer)
        {
            _iApiManager = iApiManager;
        }

        [Route("Find/{predicate}")]
        [HttpGet]
        public HttpResponseMessage Find(Expression<Func<Product, bool>> predicate)
        {
            return OkResponse(_iApiManager.GetAsync<Product>("ProductApi", "Find", null));
        }

        [Route("Get/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            Dictionary<string, string> apiParams = new Dictionary<string, string>();
            apiParams.Add("id", id);
            return OkResponse(_iApiManager.GetAsync<Product>("productapi", "Get", apiParams));
        }

        [Route("GetAllProducts")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            //return OkResponse(_iApiManager.GetAsync<Product>("productapi", "GetAllProducts", null));
            IEnumerable<Product> productData = _iApiManager.GetAsync<IEnumerable<Product>>("productapi", "GetAllProducts", null).Result;
            return OkResponse(productData);
        }

        [Route("GetAllByFilters/{includeProperties}")]
        [HttpGet]
        public HttpResponseMessage GetAllByFilters(params Expression<Func<Product, object>>[] includeProperties)
        {
            Dictionary<string, string> apiParams = new Dictionary<string, string>();
            apiParams.Add("includeProperties", includeProperties.ToString());
            return OkResponse(_iApiManager.GetAsync<Product>("productapi", "GetAllByFilters", apiParams));
        }

        [Route("GetProductsByCategory/{categoryId}")]
        [HttpGet]
        public HttpResponseMessage GetProductsByCategory(string categoryId)
        {
            Dictionary<string, string> apiParams = new Dictionary<string, string>();
            apiParams.Add("categoryId", categoryId);
            return OkResponse(_iApiManager.GetAsync<Product>("productapi", "GetProductsByCategory", apiParams));
        }

        [Route("GetProductsBySupplier/{supplierId}")]
        [HttpGet]
        public HttpResponseMessage GetProductsBySupplier(string supplierId)
        {
            Dictionary<string, string> apiParams = new Dictionary<string, string>();
            apiParams.Add("categoryId", supplierId);
            return OkResponse(_iApiManager.GetAsync<Product>("productapi", "GetProductsBySupplier", apiParams));
        }

        [Route("AddProduct")]
        [HttpPost]
        public bool Add(Product entity)
        {
            _iApiManager.PostAsync<Product>("productapi", "Add", entity);
            return true;
        }
    }
}
