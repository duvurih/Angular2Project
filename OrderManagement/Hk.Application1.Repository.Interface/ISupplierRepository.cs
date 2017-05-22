using Hk.Application1.Core.Models;
using Hk.Utilities.Interfaces;
using System.Collections.Generic;

namespace Hk.Application1.Repository.Interface
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        IEnumerable<Supplier> GetAllSupplierProducts(int supplierId);
    }
}
