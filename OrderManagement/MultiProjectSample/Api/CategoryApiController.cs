using Hk.Application1.Core.Models;
using Hk.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MultiProjectSample.Api
{
    [Authorize]
    [RoutePrefix("CategoryApiWeb")]
    public class CategoryApiController : BaseApiController
    {
        private IServiceManager _iServiceApiManager;

        public CategoryApiController(ISerializer serializer, IServiceManager iServiceApiManager) : base(serializer)
        {
            _iServiceApiManager = iServiceApiManager;
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteMultiple(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage Find(Expression<Func<Category, bool>> predicate)
        {
            return OkResponse(_iServiceApiManager.GetAsync<Product>("CategoryApi", "Find", null));
        }

        public HttpResponseMessage First(Expression<Func<Category, bool>> where)
        {
            throw new NotImplementedException();
        }

        [Route("Get/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            Dictionary<string, string> apiParams = new Dictionary<string, string>();
            apiParams.Add("id", id);
            return OkResponse(_iServiceApiManager.GetAsync<Product>("categoryapi", "Get", apiParams));
        }

        [Route("GetAllCategories")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            IEnumerable<Category> categoryData = _iServiceApiManager.GetAsync<IEnumerable<Category>>("categoryapi", "GetAllCategories", null);
            return OkResponse(categoryData);
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllByFilters(params Expression<Func<Category, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category entity)
        {
            throw new NotImplementedException();
        }

        public void InsertMultiple(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }

        public Category Single(Expression<Func<Category, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
