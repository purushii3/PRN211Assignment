using BusinessObjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly OrderDetailRepository orderDetailRepository;
        public void CreateOrderDetail(OrderDetail orderDetail) => orderDetailRepository.CreateOrderDetail(orderDetail);

        public void DeleteOrderDetail(OrderDetail orderDetail) => orderDetailRepository.DeleteOrderDetail(orderDetail);

        public List<OrderDetail> GetOrderDetails(string id) => orderDetailRepository.GetOrderDetails(id);
     
        public void UpdateOrderDetail(OrderDetail orderDetail) => orderDetailRepository.UpdateOrderDetail(orderDetail);
    }
}
