using Hk.Application1.Core.Models;
using Hk.Utilities.Interfaces;
using System.Collections.Generic;

namespace Hk.Application1.Core.Interfaces
{
    public interface ISupplierService : IGenericService<Supplier>
    {
        IEnumerable<Supplier> GetAllSupplierProducts(int supplierId);
    }
}
