using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        // Lấy tất cả đơn hàng
        public List<Order> GetAllOrders()
        {
            return OrderDAO.GetAllOrders();
        }

        // Lấy đơn hàng theo ID
        public Order GetOrderById(string id)
        {
            return OrderDAO.GetOrderById(id);
        }

        // Tạo đơn hàng mới cùng với các chi tiết đơn hàng
        public void CreateOrder(Order order, List<OrderDetail> orderDetails)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order can't be null!");
            }

            if (orderDetails == null || orderDetails.Count == 0)
            {
                throw new ArgumentException("Order must contain at least one OrderDetail!");
            }

            OrderDAO.CreateOrder(order, orderDetails);
        }

        // Cập nhật đơn hàng
        public void UpdateOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order can't be null!");
            }

            OrderDAO.UpdateOrder(order);
        }

        // Xóa đơn hàng theo ID
        public void DeleteOrder(string id)
        {
            var order = GetOrderById(id);
            if (order == null)
            {
                throw new ArgumentException("Order not found!");
            }

            OrderDAO.DeleteOrder(order);
        }
    }
}
