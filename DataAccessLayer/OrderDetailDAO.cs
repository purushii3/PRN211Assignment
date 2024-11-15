using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class OrderDetailDAO
    {
        public static void CreateOrderDetail(OrderDetail orderDetail)
        {
            using var db = new KoiFishContext();
            db.OrderDetails.Add(orderDetail);
            db.SaveChanges();
        }
        public static void UpdateOrderDetail(OrderDetail orderDetail)
        {
            using var db = new KoiFishContext();
            db.Entry<OrderDetail>(orderDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
        public static List<OrderDetail> GetAllOrderDetail(string id)
        {
            try
            {
                using var db = new KoiFishContext();
                return db.OrderDetails
                    .Include(o => o.Order)
                    .Include(k => k.KoiFish)
                    .Where(o => o.OrderId.Equals(id))
                    .Where(o => o.Status == true)
                    .ToList();
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using var db = new KoiFishContext();
                var detail = db.OrderDetails.SingleOrDefault(d => d.OrderId.Equals(orderDetail.OrderId) 
                                                                  && d.KoiFishId == orderDetail.KoiFishId);
                if (detail != null)
                {
                    detail.Status = false;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
