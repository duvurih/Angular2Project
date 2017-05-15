using Hk.Application1.Core.Models;
using Hk.Application1.Data.Models;
using Hk.Application1.Repository.GenericRepository;
using Hk.Application1.Repository.Interface;
using System;

namespace Hk.Application1.Repository.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContext context) : base(context)
        {
        }

        public Category GetCategoryById(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
