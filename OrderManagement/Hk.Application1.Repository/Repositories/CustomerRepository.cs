using Hk.Application1.Core.Models;
using Hk.Application1.Data.Models;
using Hk.Application1.Repository.GenericRepository;
using Hk.Application1.Repository.Interface;
using System;
using System.Collections.Generic;

namespace Hk.Application1.Repository.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DatabaseContext context) : base(context)
        {
        }

        public IEnumerable<Customer> GetAllCustomerProducts(int customerId)
        {
            throw new NotImplementedException();
        }

        public DatabaseContext AppContext
        {
            get { return _context as DatabaseContext; }
        }
    }
}
