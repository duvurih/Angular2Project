using Hk.Application1.Core.Models;
using Hk.Utilities.Interfaces;
using System.Collections.Generic;

namespace Hk.Application1.Repository.Interface
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetAllCustomerProducts(string customerId);

        Customer GetCustomerById(string customerId);
    }
}
