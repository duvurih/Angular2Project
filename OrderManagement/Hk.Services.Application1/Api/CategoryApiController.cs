using Hk.Application1.Core.Interfaces;
using Hk.Application1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hk.Services.Application1.Api
{
    [RoutePrefix("api/categoryapi")]
    public class CategoryApiController : ApiController
    {
        ICategoryService _iCategoryService;

        public CategoryApiController(ICategoryService iCategoryService)
        {
            _iCategoryService = iCategoryService;
        }

        public void Delete(Category entity)
        {
            _iCategoryService.Delete(entity);
        }

        public async Task DeleteAsync(int Id)
        {
            await _iCategoryService.DeleteAsync(Id);
        }

        public void DeleteMultiple(IEnumerable<Category> entities)
        {
            _iCategoryService.DeleteMultiple(entities);
        }

        [Route("find/{predicate}")]
        [HttpGet]
        public IEnumerable<Category> Find(Expression<Func<Category, bool>> predicate)
        {
            return _iCategoryService.Find(predicate);
        }

        public Category First(Expression<Func<Category, bool>> where)
        {
            return _iCategoryService.First(where);
        }

        [Route("Get/{id}")]
        [HttpGet]
        public Category Get(int id)
        {
            return _iCategoryService.Get(id);
        }

        [Route("GetAllCategories")]
        [HttpGet]
        public IEnumerable<Category> GetAll()
        {
            return _iCategoryService.GetAll();
        }

        [Route("GetAllCategoriesAsync")]
        [HttpGet]
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _iCategoryService.GetAllAsync();
        }

        [Route("GetAllByFilters/{includeProperties}")]
        [HttpGet]
        public IEnumerable<Category> GetAllByFilters(params Expression<Func<Category, object>>[] includeProperties)
        {
            return _iCategoryService.GetAllByFilters(includeProperties);
        }

        [Route("GetAsync/{id}")]
        [HttpGet]
        public async Task<Category> GetAsync(int id)
        {
            return await _iCategoryService.GetAsync(id);
        }

        [Route("GetCategoryById/{categoryId}")]
        [HttpGet]
        public Category GetCategoryById(int categoryId)
        {
            return _iCategoryService.GetCategoryById(categoryId);
        }

        [Route("AddCategory")]
        [HttpPost]
        public void Insert(Category entity)
        {
            _iCategoryService.Insert(entity);
        }

        [Route("AddMultipleCategories")]
        [HttpPost]
        public void InsertMultiple(IEnumerable<Category> entities)
        {
            _iCategoryService.InsertMultiple(entities);
        }

        public Category Single(Expression<Func<Category, bool>> where)
        {
            return _iCategoryService.Single(where);
        }

        [Route("UpdateCategory")]
        [HttpPost]
        public void Update(Category entity)
        {
            _iCategoryService.Update(entity);
        }
    }
}
