using Hk.Application1.Core.Models;
using Hk.Utilities.Interfaces;
using System.Collections.Generic;

namespace Hk.Application1.Repository.Interface
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetOrdersByCustomerId(string customerId);

        IEnumerable<Order_Detail> GetOrderDetailByOrderId(int orderId);

    }
}
