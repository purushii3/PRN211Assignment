using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;

namespace Services
{
    public interface IOrderDetailService
    {
        public List<OrderDetail> GetOrderDetails(string id);
        public void CreateOrderDetail(OrderDetail orderDetail);
        public void UpdateOrderDetail(OrderDetail orderDetail);
        public void DeleteOrderDetail(OrderDetail orderDetail);
    }
}
