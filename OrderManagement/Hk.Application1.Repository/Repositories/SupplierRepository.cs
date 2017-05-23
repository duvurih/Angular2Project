using Hk.Application1.Core.Models;
using Hk.Application1.Data.Models;
using Hk.Application1.Repository.GenericRepository;
using Hk.Application1.Repository.Interface;
using System;
using System.Collections.Generic;

namespace Hk.Application1.Repository.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(DatabaseContext context) : base(context)
        {
        }

        public IEnumerable<Supplier> GetAllSupplierProducts(int supplierId)
        {
            throw new NotImplementedException();
        }

        public DatabaseContext AppContext
        {
            get { return _context as DatabaseContext; }
        }
    }
}
