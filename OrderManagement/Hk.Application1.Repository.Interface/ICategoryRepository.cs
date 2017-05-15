using Hk.Application1.Core.Models;
using Hk.Utilities.Interfaces;

namespace Hk.Application1.Repository.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategoryById(int categoryId);
    }
}
