using BusinessObjects.Models;
using System.Collections.Generic;

namespace Services
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetOrderById(string id);
        void CreateOrder(Order order, List<OrderDetail> orderDetails);
        void UpdateOrder(Order order);
        void DeleteOrder(string id);
    }
}
