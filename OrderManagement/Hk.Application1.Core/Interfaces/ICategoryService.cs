using Hk.Application1.Core.Models;
using Hk.Utilities.Interfaces;

namespace Hk.Application1.Core.Interfaces
{
    public interface ICategoryService : IGenericService<Category>
    {
        Category GetCategoryById(int categoryId);

    }
}
