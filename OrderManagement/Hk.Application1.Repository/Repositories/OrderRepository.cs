using Hk.Application1.Core.Models;
using Hk.Application1.Data.Models;
using Hk.Application1.Repository.GenericRepository;
using Hk.Application1.Repository.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Hk.Application1.Repository.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DatabaseContext context) : base(context)
        {
        }

        public override Order Get(int id)
        {
            IEnumerable<Order> result = AppContext.Orders
                .Include(ord => ord.Customer)
                .Include(ord => ord.Order_Details)
                .Include(ord => ord.Order_Details.Select(c => c.Product))
                .Where(ord => ord.OrderID == id);
            return result.ToList()[0];
        }

        public IEnumerable<Order_Detail> GetOrderDetailByOrderId(int orderId)
        {
            return AppContext.Order_Details.Where(p => p.OrderID == orderId);
        }

        public IEnumerable<Order> GetOrdersByCustomerId(string customerId)
        {
            return AppContext.Orders.Where(p => p.CustomerID == customerId);
        }

        public DatabaseContext AppContext
        {
            get { return _context as DatabaseContext; }
        }
    }
}
