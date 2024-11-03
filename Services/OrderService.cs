using BusinessObjects.Models;
using Repositories;
using System;
using System.Collections.Generic;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService()
        {
            _orderRepository = new OrderRepository();
        }

        // Lấy tất cả đơn hàng
        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        // Lấy đơn hàng theo ID (kiểu chuỗi)
        public Order GetOrderById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("ID can't be null or empty!", nameof(id));
            }

            return _orderRepository.GetOrderById(id);
        }

        // Tạo đơn hàng mới cùng các chi tiết
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

            _orderRepository.CreateOrder(order, orderDetails);
        }

        // Cập nhật đơn hàng
        public void UpdateOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order can't be null!");
            }

            _orderRepository.UpdateOrder(order);
        }

        // Xóa đơn hàng theo ID (kiểu chuỗi)
        public void DeleteOrder(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("ID can't be null or empty!", nameof(id));
            }

            _orderRepository.DeleteOrder(id);
        }
    }
}
