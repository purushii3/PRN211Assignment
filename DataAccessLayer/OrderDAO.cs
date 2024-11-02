using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OrderDAO
    {
        // Get all orders
        public static List<Order> GetAllOrders()
        {
            var orderList = new List<Order>();
            try
            {
                using var context = new KoiFishContext();
                orderList = context.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderList;
        }

        // Create a new order with details
        public static void CreateOrder(Order order, List<OrderDetail> orderDetails)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order can't be null!");
            }

            if (orderDetails == null || orderDetails.Count == 0)
            {
                throw new ArgumentException("Order must contain at least one OrderDetail!");
            }

            try
            {
                using var context = new KoiFishContext();

                // Add the order
                context.Orders.Add(order);
                context.SaveChanges();

                // Add each order detail with the newly created order ID
                foreach (var detail in orderDetails)
                {
                    detail.OrderId = order.OrderId; // Set the foreign key to the order ID
                    context.OrderDetails.Add(detail);
                }

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update an order
        public static void UpdateOrder(Order order)
        {
            try
            {
                using var context = new KoiFishContext();
                context.Entry<Order>(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Delete an order
        public static void DeleteOrder(Order order)
        {
            try
            {
                using var context = new KoiFishContext();
                var ord = context.Orders.SingleOrDefault(o => o.OrderId == order.OrderId);
                if (ord != null)
                {
                    context.Orders.Remove(ord);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Get order by ID
        public static Order GetOrderById(string id)
        {
            using var context = new KoiFishContext();
            return context.Orders.FirstOrDefault(o => o.OrderId.Equals(id));
        }
    }
}
