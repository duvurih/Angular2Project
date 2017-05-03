using Hk.Application1.Core.Models;
using Hk.Application1.Data.Models;
using Hk.Application1.Repository.GenericRepository;
using Hk.Application1.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Hk.Application1.Repository.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext context) : base(context)
        {

        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return AppContext.Products.Where(p => p.CategoryID == categoryId);
        }

        public IEnumerable<Product> GetProductsBySupplier(int supplierId)
        {
            return AppContext.Products.Where(p => p.SupplierID == supplierId);
        }

        public DatabaseContext AppContext
        {
            get { return _context as DatabaseContext; }
        }
    }
}
