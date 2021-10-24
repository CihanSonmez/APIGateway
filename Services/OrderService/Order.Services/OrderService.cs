using Order.Infrastructure;
using Order.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDbOperations<OrderDto> _db;
        public OrderService(IDbOperations<OrderDto> db)
        {
            _db = db;
        }
        public bool ChangeStatus(string uuid, string status)
        {
            return _db.ChangeStatusAsync(uuid, status).Result;
        }

        public string Create(OrderDto order)
        {
            return _db.CreateOrderAsync(order).Result;
        }

        public bool Delete(string uuid)
        {
            return _db.DeleteOrderAsync(uuid).Result;
        }

        public IEnumerable<OrderDto> Get()
        {
            return _db.GetAllOrdersAsync().Result;
        }

        public OrderDto Get(string uuid)
        {
            return _db.GetOrderByUuidAsync(uuid).Result;
        }

        public bool Update(OrderDto order)
        {
            return _db.UpdateOrderAsync(order).Result;
        }
    }
}
