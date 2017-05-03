using Hk.Application1.Core.Interfaces;
using Hk.Application1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hk.Services.Application1.Api
{
    [RoutePrefix("api/productapi")]
    public class ProductApiController : ApiController
    {
        IProductService _iProductService;
        //IApiManager _iApiManager;

        public ProductApiController(IProductService iProductService) //, IApiManager iApiManager)
        {
            _iProductService = iProductService;
            //_iApiManager = iApiManager;
        }

        [Route("find/{predicate}")]
        [HttpGet]
        public IEnumerable<Product> Find(Expression<Func<Product, bool>> predicate)
        {
            return _iProductService.Find(predicate);
        }

        [Route("Get/{id}")]
        [HttpGet]
        public Product Get(int id)
        {
            return _iProductService.Get(id);
        }

        [Route("GetAsync/{id}")]
        public async Task<Product> GetAsync(int id)
        {
            return await _iProductService.GetAsync(id);
        }

        [Route("GetAllProducts")]
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> productData = _iProductService.GetAll();

            return productData;
        }

        [Route("GetAllProductsAsync")]
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _iProductService.GetAllAsync();
        }

        [Route("GetAllByFilters/{includeProperties}")]
        [HttpGet]
        public IEnumerable<Product> GetAllByFilters(params Expression<Func<Product, object>>[] includeProperties)
        {
            return _iProductService.GetAllByFilters(includeProperties);
        }

        [Route("GetProductsByCategory/{categoryId}")]
        [HttpGet]
        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return _iProductService.GetProductsByCategory(categoryId);
        }

        [Route("GetProductsBySupplier/{supplierId}")]
        [HttpGet]
        public IEnumerable<Product> GetProductsBySupplier(int supplierId)
        {
            return _iProductService.GetProductsBySupplier(supplierId);
        }

        [Route("AddProduct")]
        [HttpPost]
        public bool Add(Product entity)
        {

            //var smsComponent = new SmsConnectorEventService<SMSInformation>(_iApiManager);
            //var emailComponent = new eMailConnectorEventService<SMSInformation>(_iApiManager);
            //_iProductService.DataPublisher += smsComponent;
            //_iProductService.DataPublisher += emailComponent;

            _iProductService.Insert(entity);
            return true;
        }
    }
}
