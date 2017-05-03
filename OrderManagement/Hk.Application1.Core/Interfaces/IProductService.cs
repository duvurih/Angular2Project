using Hk.Application1.Core.Models;
using Hk.Utilities.Interfaces;
using System.Collections.Generic;

namespace Hk.Application1.Core.Interfaces
{
    public interface IProductService : IGenericService<Product>
    {
        IEnumerable<Product> GetProductsByCategory(int categoryId);
        IEnumerable<Product> GetProductsBySupplier(int supplierId);
    }
}
