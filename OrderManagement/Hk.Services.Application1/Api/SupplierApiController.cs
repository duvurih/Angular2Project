using Hk.Application1.Core.Interfaces;
using Hk.Application1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hk.Services.Application1.Api
{
    [RoutePrefix("api/supplierapi")]
    public class SupplierApiController : ApiController
    {
        #region "Members"
        ISupplierService _iSupplierService;
        #endregion


        public SupplierApiController(ISupplierService iSupplierService)
        {
            _iSupplierService = iSupplierService;
        }

        public async Task DeleteAsync(int Id)
        {
            await _iSupplierService.DeleteAsync(Id);
        }

        public void DeleteMultiple(IEnumerable<Supplier> entities)
        {
            _iSupplierService.DeleteMultiple(entities);
        }

        [Route("find/{predicate}")]
        [HttpGet]
        public IEnumerable<Supplier> Find(Expression<Func<Supplier, bool>> predicate)
        {
            return _iSupplierService.Find(predicate);
        }

        public Supplier First(Expression<Func<Supplier, bool>> where)
        {
            return _iSupplierService.First(where);
        }

        [Route("Get/{id}")]
        [HttpGet]
        public Supplier Get(int id)
        {
            return _iSupplierService.Get(id);
        }

        [Route("GetAllSuppliers")]
        [HttpGet]
        public IEnumerable<Supplier> GetAll()
        {
            return _iSupplierService.GetAll();
        }

        [Route("GetAllSuppliersAsync")]
        [HttpGet]
        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await _iSupplierService.GetAllAsync();
        }

        [Route("GetAllByFilters/{includeProperties}")]
        [HttpGet]
        public IEnumerable<Supplier> GetAllByFilters(params Expression<Func<Supplier, object>>[] includeProperties)
        {
            return _iSupplierService.GetAllByFilters(includeProperties);
        }

        public IEnumerable<Supplier> GetAllSupplierProducts(int supplierId)
        {
            return _iSupplierService.GetAllSupplierProducts(supplierId);
        }

        [Route("GetAsync/{id}")]
        [HttpGet]
        public async Task<Supplier> GetAsync(int id)
        {
            return await _iSupplierService.GetAsync(id);
        }

        public void Insert(Supplier entity)
        {
            _iSupplierService.Insert(entity);
        }

        public void InsertMultiple(IEnumerable<Supplier> entities)
        {
            _iSupplierService.InsertMultiple(entities);
        }

        public Supplier Single(Expression<Func<Supplier, bool>> where)
        {
            return _iSupplierService.Single(where);
        }


        #region "Add Methods"
        /// <summary>
        /// Adding new supplier
        /// </summary>
        /// <param name="entity">Supplier entity</param>
        /// <returns>Returns success or failure</returns>
        [Route("AddSupplier")]
        [HttpPost]
        public Supplier Add(Supplier entity)
        {
            return _iSupplierService.Insert(entity);
        }

        [Route("UpdateSupplier")]
        [HttpPost]
        public bool Update(Supplier entity)
        {
            _iSupplierService.Update(entity);
            return true;
        }

        [Route("DeleteSupplier")]
        [HttpPost]
        public bool Delete(Supplier entity)
        {
            _iSupplierService.Delete(entity);
            return true;
        }
        #endregion
    }
}
