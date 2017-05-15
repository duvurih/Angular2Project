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
        #region "Members"
        IProductService _iProductService;
        #endregion

        #region "Constructor"
        /// <summary>
        /// Constructor injecting product service
        /// </summary>
        /// <param name="iProductService"></param>
        public ProductApiController(IProductService iProductService)
        {
            _iProductService = iProductService;
        }
        #endregion

        #region "Get Methods"
        /// <summary>
        /// Find method accepting predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        [Route("find/{predicate}")]
        [HttpGet]
        public IEnumerable<Product> Find(Expression<Func<Product, bool>> predicate)
        {
            return _iProductService.Find(predicate);
        }

        /// <summary>
        /// Get Product by ID
        /// </summary>
        /// <param name="id">Product Identifier</param>
        /// <returns>Returns single product</returns>
        [Route("Get/{id}")]
        [HttpGet]
        public Product Get(int id)
        {
            return _iProductService.Get(id);
        }

        /// <summary>
        /// Get Product asynchronosly by product identifier
        /// </summary>
        /// <param name="id">Product Identifier</param>
        /// <returns>Returns single product</returns>
        [Route("GetAsync/{id}")]
        [HttpGet]
        public async Task<Product> GetAsync(int id)
        {
            return await _iProductService.GetAsync(id);
        }

        /// <summary>
        /// Get All Products list
        /// </summary>
        /// <returns>Returns list of products</returns>
        [Route("GetAllProducts")]
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> productData = _iProductService.GetAll();

            return productData;
        }

        /// <summary>
        /// Get all products list asynchronosly
        /// </summary>
        /// <returns>Returns list of products</returns>
        [Route("GetAllProductsAsync")]
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _iProductService.GetAllAsync();
        }

        /// <summary>
        /// Get all products by filter
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns>Returns list of products</returns>
        [Route("GetAllByFilters/{includeProperties}")]
        [HttpGet]
        public IEnumerable<Product> GetAllByFilters(params Expression<Func<Product, object>>[] includeProperties)
        {
            return _iProductService.GetAllByFilters(includeProperties);
        }

        /// <summary>
        /// Get list of products based on product category identifier
        /// </summary>
        /// <param name="categoryId">Catergory Identifiere</param>
        /// <returns>Returns list of products</returns>
        [Route("GetProductsByCategory/{categoryId}")]
        [HttpGet]
        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return _iProductService.GetProductsByCategory(categoryId);
        }

        /// <summary>
        /// Get list of products based on supplier identifier
        /// </summary>
        /// <param name="supplierId">Supplier Identifier</param>
        /// <returns>Returns list of products</returns>
        [Route("GetProductsBySupplier/{supplierId}")]
        [HttpGet]
        public IEnumerable<Product> GetProductsBySupplier(int supplierId)
        {
            return _iProductService.GetProductsBySupplier(supplierId);
        }
        #endregion

        #region "Add Methods"
        /// <summary>
        /// Adding new product
        /// </summary>
        /// <param name="entity">Product entity</param>
        /// <returns>Returns success or failure</returns>
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
        #endregion
    }
}
