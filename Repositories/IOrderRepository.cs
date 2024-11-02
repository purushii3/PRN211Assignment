using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetOrderById(string id);
        void CreateOrder(Order order, List<OrderDetail> orderDetails);
        void UpdateOrder(Order order);
        void DeleteOrder(string id);
    }
}
