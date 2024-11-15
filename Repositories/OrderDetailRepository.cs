using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public List<OrderDetail> GetOrderDetails(string id) => OrderDetailDAO.GetAllOrderDetail(id);

        public void CreateOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.CreateOrderDetail(orderDetail);
        public void DeleteOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.DeleteOrderDetail(orderDetail);
        public void UpdateOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.UpdateOrderDetail(orderDetail);
    }
}
