using Hk.Application1.Core.Models;
using Hk.Utilities.Interfaces;
using System.Collections.Generic;

namespace Hk.Application1.Core.Interfaces
{
    public interface IOrderService : IGenericService<Order>
    {
        IEnumerable<Order> GetOrdersByCustomerId(string customerId);

        IEnumerable<Order_Detail> GetOrderDetailByOrderId(int orderId);
    }
}
